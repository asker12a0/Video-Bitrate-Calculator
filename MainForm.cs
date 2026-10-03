using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Text.RegularExpressions; // Added for FPS parsing
using System.Diagnostics; // Make sure this is at the very top of your file

namespace VideoBitrateCalculator
{
    public partial class MainForm : Form
    {
        // Flag to prevent infinite loops during TextChanged events
        private bool isUpdating = false;
        // Drop Down Tool Tip
        private ToolStripDropDown fpsDropDown;
        private ToolStripDropDown pixelDropDown;
        private Form helpWindow; // The dynamic window
        private RichTextBox rtbHelp; // For multi-colored text
        public enum DockSide { Center, Left, Right, Top, Bottom }
        private DockSide currentDock = DockSide.Center; // Default to Center

        // 1. The Rule Structure HighlightRule
        private class HighlightRule
        {
            public TextBox TargetTextBox { get; set; }
            public Color HighlightColor { get; set; }
        }

        // 2. The Dictionary Map (The "Source of Truth")
        // Key = Your Button Name, Value = List of rules for that button
        private Dictionary<Button, List<HighlightRule>> _buttonHighlightMap = new Dictionary<Button, List<HighlightRule>>();

        public MainForm()
        {
            InitializeComponent();
            SetupEvents();
            SetupHighlightMappings(); // Call this to initialize the logic
        }

        private void SetupEvents()
        {
            // 1. Unit Conversion Events (Keep as TextChanged for live updates)
            BytesSum.TextChanged += Size_TextChanged;
            bitsSum.TextChanged += Size_TextChanged;
            kiloBytesSum.TextChanged += Size_TextChanged;
            kibiBytesSum.TextChanged += Size_TextChanged;
            megaBytesSum.TextChanged += Size_TextChanged;
            mebiBytesSum.TextChanged += Size_TextChanged;
            gigaBytesSum.TextChanged += Size_TextChanged;
            gibiBytesSum.TextChanged += Size_TextChanged;

            // 2. Time Conversion Events
            txtHours.Leave += Time_Changed;
            txtMinutes.Leave += Time_Changed;
            txtSeconds.Leave += Time_Changed;
            txtHours.KeyDown += KeyDown_TimeBox;
            txtMinutes.KeyDown += KeyDown_TimeBox;
            txtSeconds.KeyDown += KeyDown_TimeBox;

            this.MouseDown += Form1_MouseDown;
            txtTotalSeconds.TextChanged += Time_Changed;

            // 3. Button Click Events
            VideoBitrateFromTimeSizeAudio.Click += button1_Click;
            SizeFromTimeAndBitrate.Click += CalculateSizeFromSpecs_Click;
            btnPixelSelect.Click += btnPixelSelect_Click; // Register the new dropdown button
            btnVideoSize.Click += btnVideoSize_Click;
            btnAudioSize.Click += btnAudioSize_Click;
            btnTimeFromBitrateFileSize.Click += btnTimeFromBitrateFileSize_Click;

            // Register TextChanged for BitPixel calculation
            txtWidth.TextChanged += UpdateBitPixelCalculation;
            txtHeight.TextChanged += UpdateBitPixelCalculation;
            txtFrameRate.TextChanged += UpdateBitPixelCalculation;
            txtVideobitrate.TextChanged += UpdateBitPixelCalculation;
            textBitPixel.TextChanged += UpdateVideobitrateFromBPP;
            txtOverhead.TextChanged += UpdateTotalBitrate;

            // Register new Preset Buttons
            btnRaw.Click += btnRaw_Click;
            btnMP4.Click += btnMP4_Click;
            btnH264baseline.Click += btnH264baseline_Click;
            btnH264high.Click += btnH264high_Click;
            btnH265Main.Click += btnH265Main_Click;
            btnOverhead.Click += btnOverhead_Click;

            // Add these inside SetupEvents()
            txtVideobitrate.TextChanged += UpdateTotalBitrate;
            txtAudiobitrate.TextChanged += UpdateTotalBitrate;

            // This tells the ToolTip component which label to watch
            // and what text to show when hovered.
            toolTip1.SetToolTip(linkVideoBitrateCalculator, "https://www.dr-lex.be/info-stuff/video-bitrate-calculator.html");

        }

        #region Logic Calculations

        private void Size_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;

            System.Windows.Forms.TextBox current = (System.Windows.Forms.TextBox)sender;
            double value = 0;

            if (double.TryParse(current.Text, out value))
            {
                double bytes = 0;

                switch (current.Name)
                {
                    case "BytesSum": bytes = value; break;
                    case "bitsSum": bytes = value / 8; break;
                    case "kiloBytesSum": bytes = value * 1000; break;
                    case "kibiBytesSum": bytes = value * 1024; break;
                    case "megaBytesSum": bytes = value * 1000 * 1000; break;
                    case "mebiBytesSum": bytes = value * 1024 * 1024; break;
                    case "gigaBytesSum": bytes = value * 1000 * 1000 * 1000; break;
                    case "gibiBytesSum": bytes = value * 1024 * 1024 * 1024; break;
                }

                UpdateAllSizeFields(bytes, current.Name);
            }
        }

        private void UpdateAllSizeFields(double bytes, string sourceName)
        {
            isUpdating = true;
            try
            {
                if (sourceName != "BytesSum") BytesSum.Text = Math.Round(bytes).ToString();
                if (sourceName != "bitsSum") bitsSum.Text = Math.Round(bytes * 8, 2).ToString();
                if (sourceName != "kiloBytesSum") kiloBytesSum.Text = Math.Round(bytes / 1000, 2).ToString();
                if (sourceName != "kibiBytesSum") kibiBytesSum.Text = Math.Round(bytes / 1024, 2).ToString();
                if (sourceName != "megaBytesSum") megaBytesSum.Text = Math.Round(bytes / (1000 * 1000), 2).ToString();
                if (sourceName != "mebiBytesSum") mebiBytesSum.Text = Math.Round(bytes / (1024 * 1024), 2).ToString();
                if (sourceName != "gigaBytesSum") gigaBytesSum.Text = Math.Round(bytes / (1000 * 1000 * 1000), 2).ToString();
                if (sourceName != "gibiBytesSum") gibiBytesSum.Text = Math.Round(bytes / (1024 * 1024 * 1024), 2).ToString();
            }
            finally
            {
                isUpdating = false;
            }
        }

        private void Time_Changed(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox current = (System.Windows.Forms.TextBox)sender;
            ProcessTimeUpdate(current);
        }

        private void KeyDown_TimeBox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.TextBox current = (System.Windows.Forms.TextBox)sender;
                ProcessTimeUpdate(current);
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtHours.Focused || txtMinutes.Focused || txtSeconds.Focused)
            {
                if (txtHours.Focused) ProcessTimeUpdate((System.Windows.Forms.TextBox)txtHours);
                else if (txtMinutes.Focused) ProcessTimeUpdate((System.Windows.Forms.TextBox)txtMinutes);
                else if (txtSeconds.Focused) ProcessTimeUpdate((System.Windows.Forms.TextBox)txtSeconds);
            }
        }

        private void ProcessTimeUpdate(System.Windows.Forms.TextBox current)
        {
            if (isUpdating) return;

            double val = 0;
            if (!double.TryParse(current.Text, out val)) return;

            double totalSeconds = 0;

            double h = 0, m = 0, s = 0;
            double.TryParse(txtHours.Text, out h);
            double.TryParse(txtMinutes.Text, out m);
            double.TryParse(txtSeconds.Text, out s);

            if (current.Name == "txtTotalSeconds")
            {
                totalSeconds = val;
            }
            else if (current.Name == "txtHours")
            {
                totalSeconds = (val * 3600) + (m * 60) + s;
            }
            else if (current.Name == "txtMinutes")
            {
                totalSeconds = (h * 3600) + (val * 60) + s;
            }
            else if (current.Name == "txtSeconds")
            {
                totalSeconds = (h * 3600) + (m * 60) + val;
            }

            UpdateTimeFields(totalSeconds, current.Name);
        }

        private void UpdateTimeFields(double totalSec, string sourceName)
        {
            isUpdating = true;
            try
            {
                int hours = (int)(totalSec / 3600);
                int minutes = (int)((totalSec % 3600) / 60);
                int seconds = (int)(totalSec % 60);

                txtTotalSeconds.Text = Math.Round(totalSec).ToString();
                txtHours.Text = hours.ToString().PadLeft(2, '0');
                txtMinutes.Text = minutes.ToString().PadLeft(2, '0');
                txtSeconds.Text = seconds.ToString().PadLeft(2, '0');
            }
            finally
            {
                isUpdating = false;
            }
        }

        // --- Video Bitrate From Time Size Audio CALCULATION ---
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtTotalSeconds.Text, out double totalSec) &&
                double.TryParse(BytesSum.Text, out double sizeBytes))
            {
                double audioBitrateKbps = 0;
                double overheadKbps = 0; // New variable

                // Parse inputs
                double.TryParse(txtAudiobitrate.Text, out audioBitrateKbps);
                double.TryParse(txtOverhead.Text, out overheadKbps); // Parse Overhead

                double totalBits = sizeBytes * 8;
                double totalBitrateKbps = (totalSec > 0) ? (totalBits / totalSec) / 1000 : 0;

                // Subtract BOTH Audio and Overhead from the Total to get Video
                double videoBitrate = totalBitrateKbps - audioBitrateKbps - overheadKbps;

                // Prevent negative results if inputs are incorrect
                if (videoBitrate < 0) videoBitrate = 0;

                txtVideobitrate.Text = Math.Round(videoBitrate, 2).ToString();
                txtTotalbitrate.Text = Math.Round(totalBitrateKbps, 2).ToString();

                UpdateTotalBitrate(null, null);
            }
        }

        // --- Audio Bitrate From Time Size Video CALCULATION ---
        private void AudioBitrateFromTimeSizeVideo_Click(object sender, EventArgs e)
        {
            if (isUpdating) return;

            double totalSeconds = 0;
            double videoBitrateKbps = 0;
            double sizeBytes = 0;
            double overheadKbps = 0; // New variable

            // Parse inputs from the UI
            double.TryParse(txtTotalSeconds.Text, out totalSeconds);
            double.TryParse(txtVideobitrate.Text, out videoBitrateKbps);
            double.TryParse(BytesSum.Text, out sizeBytes);
            double.TryParse(txtOverhead.Text, out overheadKbps); // Parse Overhead

            if (totalSeconds > 0)
            {
                // 1. Calculate Total Bits: Bytes * 8
                double totalBits = sizeBytes * 8;

                // 2. Calculate Total Bitrate in kbps: (Total Bits / Seconds) / 1000
                double totalBitrateKbps = (totalBits / totalSeconds) / 1000;

                // 3. Subtract Video Bitrate AND Overhead to get Audio Bitrate
                double audioBitrateKbps = totalBitrateKbps - videoBitrateKbps - overheadKbps;

                // Prevent negative results if inputs are incorrect
                if (audioBitrateKbps < 0) audioBitrateKbps = 0;

                // Output result to txtAudiobitrate
                txtAudiobitrate.Text = Math.Round(audioBitrateKbps, 2).ToString();
            }
        }

        // --- Calculate File size From Time Video,Audio or Apart ---
        private void CalculateSizeFromSpecs_Click(object sender, EventArgs e)
        {
            if (isUpdating) return;

            double videoBitrate = 0;
            double audioBitrate = 0;
            double totalSeconds = 0;

            // Parse Video Bitrate
            double.TryParse(txtVideobitrate.Text, out videoBitrate);
            // Parse Audio Bitrate
            double.TryParse(txtAudiobitrate.Text, out audioBitrate);
            // Parse Total Seconds
            double.TryParse(txtTotalSeconds.Text, out totalSeconds);

            if (totalSeconds > 0)
            {
                // Calculation:
                // 1. Get Total Bitrate in kbps
                double totalBitrateKbps = videoBitrate + audioBitrate;

                // 2. Convert to bits per second (bps)
                double totalBitrateBps = totalBitrateKbps * 1000;

                // 3. Calculate Total Bits: Bitrate * Time
                double totalBits = totalBitrateBps * totalSeconds;

                // 4. Convert to Bytes
                double bytes = totalBits / 8;

                // Update all size fields (KB, MB, GB, etc.)
                UpdateAllSizeFields(bytes, "Result");
            }
        }
        // --- Calculate File size From Time Video ---
        private void btnVideoSize_Click(object sender, EventArgs e)
        {
            if (isUpdating) return;

            double videoBitrate = 0;
            double totalSeconds = 0;

            // Parse Video Bitrate
            double.TryParse(txtVideobitrate.Text, out videoBitrate);
            // Parse Total Seconds
            double.TryParse(txtTotalSeconds.Text, out totalSeconds);

            if (totalSeconds > 0)
            {
                // Calculation:
                // 1. Get Total Bitrate in kbps
                double totalBitrateKbps = videoBitrate;

                // 2. Convert to bits per second (bps)
                double totalBitrateBps = totalBitrateKbps * 1000;

                // 3. Calculate Total Bits: Bitrate * Time
                double totalBits = totalBitrateBps * totalSeconds;

                // 4. Convert to Bytes
                double bytes = totalBits / 8;

                // Update all size fields (KB, MB, GB, etc.)
                UpdateAllSizeFields(bytes, "Result");
            }
        }
        // --- Calculate File size From Time Audio ---
        private void btnAudioSize_Click(object sender, EventArgs e)
        {
            if (isUpdating) return;

            double audioBitrate = 0;
            double totalSeconds = 0;

            // Parse Audio Bitrate
            double.TryParse(txtAudiobitrate.Text, out audioBitrate);
            // Parse Total Seconds
            double.TryParse(txtTotalSeconds.Text, out totalSeconds);

            if (totalSeconds > 0)
            {
                // Calculation:
                // 1. Get Total Bitrate in kbps
                double totalBitrateKbps = audioBitrate;

                // 2. Convert to bits per second (bps)
                double totalBitrateBps = totalBitrateKbps * 1000;

                // 3. Calculate Total Bits: Bitrate * Time
                double totalBits = totalBitrateBps * totalSeconds;

                // 4. Convert to Bytes
                double bytes = totalBits / 8;

                // Update all size fields (KB, MB, GB, etc.)
                UpdateAllSizeFields(bytes, "Result");
            }
        }
        private void btnTimeFromBitrateFileSize_Click(object sender, EventArgs e)
        {
            if (isUpdating) return;

            double totalBitrateKbps = 0;
            double sizeBytes = 0;

            // Parse inputs from UI
            double.TryParse(txtTotalbitrate.Text, out totalBitrateKbps);
            double.TryParse(BytesSum.Text, out sizeBytes);

            if (totalBitrateKbps > 0)
            {
                // Calculation Logic:
                // 1. Convert Bytes to Bits (Size * 8)
                double totalBits = sizeBytes * 8;

                // 2. Convert kbps to bps (Bitrate * 1000)
                double bitrateBps = totalBitrateKbps * 1000;

                // 3. Calculate Total Seconds (Total Bits / Bitrate in Bps)
                double totalSeconds = totalBits / bitrateBps;

                // Update the result field
                txtTotalSeconds.Text = Math.Round(totalSeconds).ToString();

                // Optional: Trigger your existing time update logic 
                // This ensures txtHours and txtMinutes also update automatically
                UpdateTimeFields(totalSeconds, "txtTotalSeconds");
            }
        }

        private void btnFPSselect_Click(object sender, EventArgs e)
        {
            fpsDropDown = new ToolStripDropDown();
            ListBox fpsList = new ListBox();

            fpsList.Items.Add("23.976 (NTSC film)");
            fpsList.Items.Add("24 (film)");
            fpsList.Items.Add("25 (PAL)");
            fpsList.Items.Add("29.97 (NTSC)");
            fpsList.Items.Add("30");
            fpsList.Items.Add("48 (for hobbits)");
            fpsList.Items.Add("50 (PAL high)");
            fpsList.Items.Add("59.94 (NTSC high)");
            fpsList.Items.Add("60");

            fpsList.Width = 120;
            fpsList.Height = 150;

            fpsList.SelectedIndexChanged += (s, args) =>
            {
                if (fpsList.SelectedItem != null)
                {
                    string selectedText = fpsList.SelectedItem.ToString();
                    // Extract only the numbers using Regex
                    var match = Regex.Match(selectedText, @"\d+\.?\d*");
                    if (match.Success)
                    {
                        txtFrameRate.Text = match.Value;
                    }
                    fpsDropDown.Close();
                }
            };

            ToolStripControlHost host = new ToolStripControlHost(fpsList);
            host.Padding = Padding.Empty;
            host.Margin = Padding.Empty;
            fpsDropDown.Padding = Padding.Empty;
            fpsDropDown.Margin = Padding.Empty;
            fpsDropDown.Items.Add(host);

            fpsDropDown.Show(btnFPSselect, new Point(btnFPSselect.Width, 0));
        }
        // --- NEW: Pixel Selection Dropdown Logic ---
        private void btnPixelSelect_Click(object sender, EventArgs e)
        {
            pixelDropDown = new ToolStripDropDown();
            ListBox pixelList = new ListBox();

            // Adding the options provided by the user
            pixelList.Items.Add("720p 16:9");
            pixelList.Items.Add("720p 1.85:1");
            pixelList.Items.Add("720p 2.39:1");
            pixelList.Items.Add("1080p 16:9");
            pixelList.Items.Add("1080p 1.85:1");
            pixelList.Items.Add("1080p 2.39:1");
            pixelList.Items.Add("UHD 16:9");
            pixelList.Items.Add("UHD 1.85:1");
            pixelList.Items.Add("UHD 2.39:1");

            pixelList.Width = 120;
            pixelList.Height = 150;

            pixelList.SelectedIndexChanged += (s, args) =>
            {
                if (pixelList.SelectedItem != null)
                {
                    string selected = pixelList.SelectedItem.ToString();
                    isUpdating = true; // Prevent TextChanged loops during the switch
                    try
                    {
                        switch (selected)
                        {
                            case "720p 16:9": txtWidth.Text = "1280"; txtHeight.Text = "720"; txtAspectRatio.Text = "1.78"; break;
                            case "720p 1.85:1": txtWidth.Text = "1280"; txtHeight.Text = "692"; txtAspectRatio.Text = "1.85"; break;
                            case "720p 2.39:1": txtWidth.Text = "1280"; txtHeight.Text = "536"; txtAspectRatio.Text = "2.39"; break;
                            case "1080p 16:9": txtWidth.Text = "1920"; txtHeight.Text = "1080"; txtAspectRatio.Text = "1.78"; break;
                            case "1080p 1.85:1": txtWidth.Text = "1920"; txtHeight.Text = "1038"; txtAspectRatio.Text = "1.85"; break;
                            case "1080p 2.39:1": txtWidth.Text = "1920"; txtHeight.Text = "800"; txtAspectRatio.Text = "2.4"; break;
                            case "UHD 16:9": txtWidth.Text = "3840"; txtHeight.Text = "2160"; txtAspectRatio.Text = "1.78"; break;
                            case "UHD 1.85:1": txtWidth.Text = "3840"; txtHeight.Text = "2076"; txtAspectRatio.Text = "1.85"; break;
                            case "UHD 2.39:1": txtWidth.Text = "3840"; txtHeight.Text = "1608"; txtAspectRatio.Text = "2.39"; break;
                        }
                    }
                    finally
                    {
                        isUpdating = false; // Turn the flag off so calculations can run

                        // MANUALLY TRIGGER THE CALCULATION HERE
                        // This ensures that even though the TextChanged events were blocked 
                        // by the 'isUpdating' flag, the final result is calculated now.
                        UpdateBitPixelCalculation(null, null);
                    }
                    pixelDropDown.Close();
                }
            };

            ToolStripControlHost host = new ToolStripControlHost(pixelList);
            host.Padding = Padding.Empty;
            host.Margin = Padding.Empty;
            pixelDropDown.Padding = Padding.Empty;
            pixelDropDown.Margin = Padding.Empty;
            pixelDropDown.Items.Add(host);

            pixelDropDown.Show(btnPixelSelect, new Point(btnPixelSelect.Width, 0));
        }
        private void SetupHighlightMappings()
        {
            // --- SCALABLE: Just add your buttons and colors here ---
            // We do NOT use "if (ContainsKey)" because we are currently BUILDING the dictionary.

            // Example 1: VideoBitrateFromTimeSizeAudio button
            _buttonHighlightMap[VideoBitrateFromTimeSizeAudio] = new List<HighlightRule> {
        new HighlightRule { TargetTextBox = BytesSum, HighlightColor = ColorTranslator.FromHtml("#E5FFE9") },
        new HighlightRule { TargetTextBox = txtAudiobitrate, HighlightColor = ColorTranslator.FromHtml("#E5FFE9") },
        new HighlightRule { TargetTextBox = txtTotalSeconds, HighlightColor = ColorTranslator.FromHtml("#E5FFE9") },
        new HighlightRule { TargetTextBox = txtTotalbitrate, HighlightColor = Color.LightYellow },
        new HighlightRule { TargetTextBox = txtVideobitrate, HighlightColor = Color.LightYellow },
        new HighlightRule { TargetTextBox = textBitPixel, HighlightColor = Color.LightYellow }
    };

            // Example 2: btnRaw button
            _buttonHighlightMap[btnRaw] = new List<HighlightRule> {
        new HighlightRule { TargetTextBox = txtVideobitrate, HighlightColor = Color.LightGreen },
        new HighlightRule { TargetTextBox = txtAudiobitrate, HighlightColor = Color.SkyBlue },
        new HighlightRule { TargetTextBox = txtTotalbitrate, HighlightColor = Color.SkyBlue }
    };

            // --- AUTOMATIC REGISTRATION ---
            // This loop looks at everything we just added above and attaches the hover events automatically.
            foreach (var entry in _buttonHighlightMap)
            {
                entry.Key.MouseEnter += (s, e) => ApplyHighlights(entry.Key);
                entry.Key.MouseLeave += (s, e) => ResetHighlights();
            }
        }

        // 3. The "Engine": Only one method handles all highlighting logic for ALL buttons
        private void ApplyHighlights(Button btn)
        {
            if (_buttonHighlightMap.ContainsKey(btn))
            {
                foreach (var rule in _buttonHighlightMap[btn])
                {
                    // Check if the textbox exists before trying to color it
                    if (rule.TargetTextBox != null)
                    {
                        rule.TargetTextBox.BackColor = rule.HighlightColor;
                    }
                }
            }
        }

        // 4. The "Reset": Only one method handles clearing colors
        private void ResetHighlights()
        {
            // We use Color.White instead of SystemColors.Window to avoid the reference error
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb)
                {
                    tb.BackColor = Color.White;
                }

                // If you have panels or groupboxes, we need to check inside them too:
                if (c.HasChildren)
                {
                    foreach (Control child in c.Controls)
                    {
                        if (child is TextBox tbChild) tbChild.BackColor = Color.White;
                    }
                }
            }
        }

        // --- BitPixel Calculation Logic ---
        private void UpdateBitPixelCalculation(object sender, EventArgs e)
        {
            if (isUpdating) return;

            // Try to parse all required values as doubles to maintain maximum precision
            bool isVideoBitrateValid = double.TryParse(txtVideobitrate.Text, out double bitrateKbps);
            bool isWidthValid = double.TryParse(txtWidth.Text, out double width);
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isFrameRateValid = double.TryParse(txtFrameRate.Text, out double frameRate);

            // 1. NEW: Auto Update Aspect Ratio (Calculates whenever Width or Height changes)
            if (isWidthValid && isHeightValid && height != 0)
            {
                double ratio = width / height;
                // Round to 2 decimal places as per your examples
                txtAspectRatio.Text = Math.Round(ratio, 2).ToString();
            }

            // 2. Existing BitPixel Calculation
            if (isVideoBitrateValid && isWidthValid && isHeightValid && isFrameRateValid)
            {
                if (width > 0 && height > 0 && frameRate > 0)
                {
                    isUpdating = true;
                    try
                    {
                        // 1. Convert bitrate from kbps to bits/second
                        double bitrateBits = bitrateKbps * 1000;

                        // 2. Calculate the number of pixels per frame
                        double pixelsPerFrame = width * height;

                        // 3. Calculate the number of pixels processed per second
                        double pixelsPerSecond = pixelsPerFrame * frameRate;

                        // 4. Calculate BPP: bitrate_bits / pixels_per_second
                        double bpp = bitrateBits / pixelsPerSecond;

                        // Update the result box with at least 6 decimal places
                        textBitPixel.Text = bpp.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture);

                        // Show the complete calculation for verification
                        if (this.Controls.ContainsKey("lblCalculation"))
                        {
                            string calculationString = $"{bitrateBits} / ({pixelsPerFrame} * {frameRate})";
                            ((System.Windows.Forms.Label)this.Controls["lblCalculation"]).Text = calculationString;
                        }
                    }
                    finally
                    {
                        isUpdating = false;
                    }
                }
            }
        }

        // --- NEW: Calculate Videobitrate From BitPixel Calculation ---
        private void UpdateVideobitrateFromBPP(object sender, EventArgs e)
        {
            if (isUpdating) return;

            // Try to parse all required values as doubles
            bool isBppValid = double.TryParse(textBitPixel.Text, out double bpp);
            bool isWidthValid = double.TryParse(txtWidth.Text, out double width);
            bool isHeightValid = double.TryParse(txtHeight.Text, out double height);
            bool isFrameRateValid = double.TryParse(txtFrameRate.Text, out double frameRate);

            // Check if all inputs are valid and non-zero to avoid division by zero
            if (isBppValid && isWidthValid && isHeightValid && isFrameRateValid)
            {
                if (width > 0 && height > 0 && frameRate > 0)
                {
                    isUpdating = true;
                    try
                    {
                        // 1. Calculate the number of pixels per frame
                        double pixelsPerFrame = width * height;

                        // 2. Calculate the number of pixels processed per second
                        double pixelsPerSecond = pixelsPerFrame * frameRate;

                        // 3. Calculate total bits per second (BPP * Pixels Per Second)
                        double bitrateBits = bpp * pixelsPerSecond;

                        // 4. Convert to kbps (bits / 1000)
                        double bitrateKbps = bitrateBits / 1000;

                        // Update the Videobitrate field
                        txtVideobitrate.Text = Math.Round(bitrateKbps, 2).ToString();

                        UpdateTotalBitrate(null, null);
                    }
                    finally
                    {
                        isUpdating = false;
                    }
                }
            }
        }

        // --- Preset Buttons Logic ---

        private void ApplyPreset(double baseBpp, bool isRaw)
        {
            if (isUpdating) return;

            double finalBpp = 0;

            if (isRaw)
            {
                finalBpp = 24.0;
            }
            else
            {
                double multiplier = 1.0;
                if (checkBoxCGI.Checked) multiplier *= 0.75;
                if (checkBoxDarkScenesStillimages.Checked) multiplier *= 0.85;
                if (checkBoxNoisyimageTreesBushes.Checked) multiplier *= 1.25;

                finalBpp = baseBpp * multiplier;
            }

            // This will now show "0.25" instead of "0.250000"
            textBitPixel.Text = finalBpp.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture);
            isUpdating = true;
            try
            {
                UpdateVideobitrateFromBPP(null, null);
                PerformTotalBitrateCalculation(); // <--- Call the CORE method here directly
            }
            finally
            {
                isUpdating = false;
            }
        }
        private void UpdateTotalBitrate(object sender, EventArgs e)
        {
            if (isUpdating) return; // Keep this check here!

            isUpdating = true;
            try
            {
                PerformTotalBitrateCalculation(); // Call the core engine
            }
            finally
            {
                isUpdating = false;
            }
        }

        // This is the "Engine" - it just does the math without checking flags
        private void PerformTotalBitrateCalculation()
        {
            double videoBitrate = 0;
            double audioBitrate = 0;
            double overhead = 0; // 1. Declare a variable for overhead

            // 2. Parse all three inputs from the UI
            double.TryParse(txtVideobitrate.Text, out videoBitrate);
            double.TryParse(txtAudiobitrate.Text, out audioBitrate);
            double.TryParse(txtOverhead.Text, out overhead); // Parse the overhead field

            // 3. Update calculation to include overhead
            double totalBitrate = videoBitrate + audioBitrate + overhead;

            // Update the UI directly
            txtTotalbitrate.Text = Math.Round(totalBitrate, 2).ToString();
        }
        private void btnOverhead_Click(object sender, EventArgs e)
        {
            if (isUpdating) return;

            double totalSeconds = 0;
            double sizeBytes = 0;
            double videoBitrateKbps = 0;
            double audioBitrateKbps = 0; // Added this variable

            // Parse inputs - Calculation only proceeds if all four are valid numbers
            bool sValid = double.TryParse(txtTotalSeconds.Text, out totalSeconds);
            bool bValid = double.TryParse(BytesSum.Text, out sizeBytes);
            bool vValid = double.TryParse(txtVideobitrate.Text, out videoBitrateKbps);
            bool aValid = double.TryParse(txtAudiobitrate.Text, out audioBitrateKbps); // Added this

            if (sValid && bValid && vValid && aValid && totalSeconds > 0)
            {
                isUpdating = true;
                try
                {
                    // 1. Convert Bytes to Bits
                    double totalBits = sizeBytes * 8;

                    // 2. Calculate Total Bitrate in kbps: (Total Bits / Seconds) / 1000
                    double totalBitrateKbps = (totalBits / totalSeconds) / 1000;

                    // 3. Calculate Overhead: Total Bitrate - (Video Bitrate + Audio Bitrate)
                    // This is the fix: we subtract both streams to find the true overhead
                    double overhead = totalBitrateKbps - (videoBitrateKbps + audioBitrateKbps);

                    // Output results
                    txtOverhead.Text = Math.Round(overhead, 2).ToString();
                    txtTotalbitrate.Text = Math.Round(totalBitrateKbps, 2).ToString();

                    // Sync with the existing engine logic
                    UpdateTotalBitrate(null, null);
                }
                finally
                {
                    isUpdating = false;
                }
            }
        }

private void btnHelp_Click(object sender, EventArgs e)
        {
            if (helpWindow == null || helpWindow.IsDisposed)
            {
                CreateHelpWindow();
            }
            helpWindow.Show();
        }
private void CreateHelpWindow()
        {
            helpWindow = new Form();
            helpWindow.Text = "Help Guide";
            helpWindow.Size = new Size(375, 450); // Made slightly taller for buttons
            helpWindow.FormBorderStyle = FormBorderStyle.FixedDialog;
            helpWindow.StartPosition = FormStartPosition.Manual;
            helpWindow.TopMost = true;

            rtbHelp = new RichTextBox();
            rtbHelp.Dock = DockStyle.Fill;
            rtbHelp.ReadOnly = true;
            rtbHelp.Font = new Font("Segoe UI", 10);

            // --- YOUR CONTENT ---
            // --- About Section ---
            rtbHelp.SelectionColor = Color.Black;
            rtbHelp.AppendText("About\n\n");
            rtbHelp.AppendText("This calculator is intended to make bitrate calculations for encoding movies easier. Fields used as inputs for a button or edit field are ");

            // Highlight: Bold and Green
            rtbHelp.SelectionColor = Color.Black;
            rtbHelp.SelectionFont = new Font(rtbHelp.Font, FontStyle.Bold); // This is the fix
            rtbHelp.AppendText("highlighted in green");
            rtbHelp.SelectionFont = new Font(rtbHelp.Font, FontStyle.Regular); // Reset to regular

            rtbHelp.SelectionColor = Color.Black;
            rtbHelp.AppendText(", and output fields ");

            // Highlight: Bold and Pale Yellow
            rtbHelp.SelectionColor = ColorTranslator.FromHtml("#000000");
            rtbHelp.SelectionFont = new Font(rtbHelp.Font, FontStyle.Bold); // This is the fix
            rtbHelp.AppendText("in pale yellow");
            rtbHelp.SelectionFont = new Font(rtbHelp.Font, FontStyle.Regular); // Reset to regular

            rtbHelp.SelectionColor = Color.Black;
            rtbHelp.AppendText(". When pushing a button or having edited a field, fields updated by this action will flash ");

            // Highlight: Bold and Bright Yellow
            rtbHelp.SelectionColor = Color.Black;
            rtbHelp.SelectionFont = new Font(rtbHelp.Font, FontStyle.Bold); // This is the fix
            rtbHelp.AppendText("bright yellow");
            rtbHelp.SelectionFont = new Font(rtbHelp.Font, FontStyle.Regular); // Reset to regular

            rtbHelp.SelectionColor = Color.Black;
            rtbHelp.AppendText("\n\nHighlighting behaviour differs between desktop and touch browsers due to these differences between a cursor- or touch-driven UI. If you prefer either or the other, or if touch UI detection should fail, the button below the calculator allows to override it.\n\n");

            rtbHelp.AppendText("Of course you are entirely free to believe you do not need calculators like these anymore, and instead try asking some A.I., only to notice that language models which are the accidental offspring of automated translator research are rather bad at accurate calculations. But don't worry: they will hide this fact by embellishing the answer with useless nonsense, further wasting your precious time and energy.\n\n");

            // --- Usage Section ---
            rtbHelp.AppendText("Usage\n\n");
            rtbHelp.AppendText("The classic use case is to determine the required video bitrate to fill a fixed-size medium like a CD-R or DVD+R, given a fixed audio bitrate and movie duration. To do this, enter the duration, audio bitrate and target size, and press the “Video from time,size,audio” button. You can do the same for audio. Total audio bitrate is the number of audio tracks times the given audio bitrate. You can use this to either represent multiple tracks (for instance languages), or multiple discrete surround channels.\n\n");

            rtbHelp.AppendText("Another useful scenario is to determine whether a video file can fit in a fixed-size medium like a DVD-R at acceptable quality. Or likewise, if you want to avoid wasting download time on a file that just seems too small to possibly offer good quality. In these cases, do the same as above to calculate the actual video bitrate and write down or memorise this number. Then enter the film's image dimensions and frame rate in the lower part of the calculator. Push the appropriate ‘Suggest bitrate’ button (see instructions below). If the suggested video bitrate is much higher than the actual one (about double or more), video quality will probably be unacceptably bad. Just to give an example: with H.264 there is no way to fit a normal two-hour film on a single CD-R at anything higher than DVD resolution without making it look or sound awful, so please do not try it.\n\n");

            rtbHelp.AppendText("Mind that sizes are given in two ‘flavours.’ If you don't know the difference between a MB and a MiB, check out my other page that explains it. Unfortunately a lot of software still uses the ‘MB’ symbol while they actually mean MiB. In case of doubt, assume KiB, MiB and GiB values: if the software does use kB, MB, and GB, your file will be slightly too small, which is not as bad as too large.\n\n");

            rtbHelp.AppendText("Overhead is what is left of the file after removing actual video and audio data. This is heavily dependent on the container format, codecs and parameters, and includes any extra streams like subtitles. This calculator assumes overhead is proportional to the length of the video, which is a simplification. In reality there will also be a one-time overhead for the file itself and metadata. In case of doubt and if the file must fit within a certain size, it's better to use a conservatively high overhead estimate.\n\n");

            // --- Bitrate Suggestion Section ---
            rtbHelp.AppendText("Bitrate suggestion\n\n");
            rtbHelp.AppendText("The ‘Suggest bitrate’ buttons try to give an OK average video bitrate estimate for a movie, based on given dimensions, frame rate, and the video codec. (If you don't know what a codec is, I have another page that explains this.) Most likely you should use either the “H.264 high” button because practically everything nowadays supports the ‘high’ H.264 profile, or the “H.265” button if you are encoding with that codec. The other buttons are legacy: the “MP4” button represents encoding with the old MPEG-4 based Xvid or DivX which only makes sense if the target is some old constrained playback device. The “H.264 baseline” button represents encoding with H.264 without advanced options like trellis, CABAC, RD, etc., which also would only be appropriate in limited situations.\n\n");

            rtbHelp.AppendText("For giggles, the “Raw” button shows bitrate for raw (uncompressed) video—try it and you'll see why codecs were invented.\n\n");

            rtbHelp.AppendText("Beware that this is not exact science. It is wet-finger guesswork because except for raw video, the actual required bitrate depends heavily on video contents. The calculation assumes you're using double-pass encoding and a ‘typical’ frame rate (around 25fps). A few checkboxes are provided to allow somewhat tuning the guess: check the ‘CGI’ box if the film consists purely or mostly of smooth computer-generated images (like Toy Story, Ice Age, …); check the ‘Dark’ box for films that have many dark shots with large parts of the image often almost pure black or out-of-focus (e.g., Dark City). Check the ‘Noisy’ button if the image is noticeably noisy throughout, has a lot of fast movement, and/or contains a lot of footage of trees, bushes or other cluttered things. For a movie like Avatar, you should check this: even though it is mostly CGI, the images are very detailed and there is a lot of action.\n\n");

            rtbHelp.AppendText("I tuned this estimator by encoding various 1080p24 video fragments at a quality where I couldn't see any image degradation in the result without rigorously comparing to the source material. The estimates deliver in my opinion a “good enough” quality on average if the goal is to stay close to the source material.\n\nThe main purpose of this tool is to check whether the bitrate you're going to use is reasonable. If you encode a film with an actual video bitrate more than twice what this estimate gives, you're probably wasting disk space unless you are adamant on preserving film grain. If your bitrate is considerably lower than this estimate, the quality of the encoding will probably be bad. How bad, depends on both the codec and the content of the video. The less detail, movement, and noise in the image, the easier it is to encode. For instance computer animations with very clean images and generally static backgrounds (like the Toy Story series) can fit in a surprisingly low bitrate without obvious quality loss. As for the codec: H.264 and similar modern codecs are very capable at gracefully degrading the image, therefore even if you go far below what this calculator suggests, it may still look OK on its own. Compared to the original or a higher bitrate encoding however, it will look obviously washed-out if bitrate is too low.\n\nBitrate requirements also tend to become less strict for higher-resolution video. This calculator does not take this fact into account, therefore you may consider the estimate the more conservative the larger your video frame size is. The same goes for higher frame rates.\n\n");

            // --- Hints Section ---
            rtbHelp.AppendText("Hints\n\n");
            rtbHelp.AppendText("Avoid relying on bitrate altogether\n\n");
            rtbHelp.AppendText("If you are encoding a film and it doesn't really matter how large the resulting file is yet you don't want to waste disk space, consider using quality-based encoding, which in most cases makes a lot more sense than using a fixed bitrate. A fixed bitrate only makes sense for streaming or storage on a fixed-size medium. I explain this in more detail in my article with video encoding tips.\n\n");

            rtbHelp.AppendText("If you're planning to encode multiple movies that must fit within a specific size, e.g., three movies in 4.7GB, do not just encode each movie to be 4.7/3 = 1.56GB. That does not make sense unless they are all the same length, frame rate, and frame size. To get a sensible idea of what the relative sizes of the movies should be, use the ‘Suggest bitrate’ feature to determine their ‘ideal’ sizes and then try to divide the total available size in chunks that have the same proportions. For instance if the calculator says that film A should be 3 GB, B 2 GB and C 1.5 GB, and you want to squeeze all three on a single 4.7 GB DVD-R, you should try to make them respectively 2.17 GB, 1.45 GB and 1.08 GB.\n\n");

            rtbHelp.AppendText("Also do not try to steal bitrate from the audio stream in order to get marginally more bits for video. The audio stream is typically much smaller anyway so there is not much to gain, and worse audio is much more annoying than slightly worse video. If you really are short on bits, consider reducing the number of audio channels (5.1 to stereo, or stereo to mono), instead of trying to squeeze too many audio channels into too low a bitrate.\n\n");

            rtbHelp.AppendText("Get true bitrates with mediainfo\n\n");
            rtbHelp.AppendText("Mediainfo normally only shows bitrates if they are stored in the file's metadata. If the bitrate numbers are not in there, they will be missing from mediainfo's output no matter what you try, unless you run it in a special mode that forces a full analysis of the file. By adding the --ParseSpeed=1 option, it will parse the entire file and recompute bitrates. This is of course way slower but you will obtain the actual values. The following example (for bash-like shells) prints true average bitrates for both video and audio.\n\n");

            rtbHelp.AppendText("mediainfo --ParseSpeed=1 --Inform=$'Video;Video: %BitRate/String%\\n\nAudio;Audio: %BitRate/String%' yourfile.mkv\n\n");

            rtbHelp.AppendText("Short note about DTS\n\n");
            rtbHelp.AppendText("If you are confused about DTS bitrates: the classic DTS audio stream has an actual bitrate of 1509 kbps (sometimes also 1509.75) but when sending it over a cable, it is encapsulated in a transmission stream of 1536 kbps, the exact rate of uncompressed stereo PCM audio. (Similar for the to-be-avoided half-bitrate variant: 754.5 and 768 kbps respectively.) Obviously when using such track in an efficient media file, only the true rate will be used.\n\n");

            rtbHelp.AppendText("©2010-2024 Alexander Thomas");

            helpWindow.Controls.Add(rtbHelp);

            // --- DOCKING BUTTONS PANEL ---
            FlowLayoutPanel dockPanel = new FlowLayoutPanel();
            dockPanel.Dock = DockStyle.Bottom;
            dockPanel.Height = 40;
            dockPanel.BackColor = Color.LightGray;

            Button btnLeft = new Button { Text = "Left", Width = 65 };
            Button btnRight = new Button { Text = "Right", Width = 65 };
            Button btnTop = new Button { Text = "Top", Width = 65 };
            Button btnBottom = new Button { Text = "Bottom", Width = 65 };
            // --- NEW CENTER BUTTON ---
            Button btnCenter = new Button { Text = "Center", Width = 65 };

            // Add buttons to panel
            dockPanel.Controls.Add(btnLeft);
            dockPanel.Controls.Add(btnRight);
            dockPanel.Controls.Add(btnTop);
            dockPanel.Controls.Add(btnBottom);
            dockPanel.Controls.Add(btnCenter); // Added to layout

            // Button Logic
            btnLeft.Click += (s, e) => { currentDock = DockSide.Left; UpdateHelpPosition(); };
            btnRight.Click += (s, e) => { currentDock = DockSide.Right; UpdateHelpPosition(); };
            btnTop.Click += (s, e) => { currentDock = DockSide.Top; UpdateHelpPosition(); };
            btnBottom.Click += (s, e) => { currentDock = DockSide.Bottom; UpdateHelpPosition(); };
            // Center Button Logic
            btnCenter.Click += (s, e) => { currentDock = DockSide.Center; UpdateHelpPosition(); };

            helpWindow.Controls.Add(dockPanel);

            // Glue logic
            this.LocationChanged += (s, e) => UpdateHelpPosition();
            this.SizeChanged += (s, e) => UpdateHelpPosition();

            UpdateHelpPosition();
        }

        private void UpdateHelpPosition()
        {
            if (helpWindow == null || helpWindow.IsDisposed) return;

            int margin = 10; // Space between the form and the help window

            switch (currentDock)
            {
                case DockSide.Left:
                    helpWindow.Location = new Point(this.Left - helpWindow.Width - margin, this.Top);
                    break;
                case DockSide.Right:
                    helpWindow.Location = new Point(this.Left + this.Width + margin, this.Top);
                    break;
                case DockSide.Top:
                    helpWindow.Location = new Point(this.Left + margin, this.Top - helpWindow.Height - margin);
                    break;
                case DockSide.Bottom:
                    helpWindow.Location = new Point(this.Left + margin, this.Bottom + margin);
                    break;
                case DockSide.Center:
                    // Calculate the center of the main form and subtract half the help window size
                    int x = this.Left + (this.Width / 2) - (helpWindow.Width / 2);
                    int y = this.Top + (this.Height / 2) - (helpWindow.Height / 2);
                    helpWindow.Location = new Point(x, y);
                    break;
            }
        }
        private void linkVideoBitrateCalculator_LinkClicked(object sender, EventArgs e)
        {
            // Replace with your desired URL
            string url = "https://www.dr-lex.be/info-stuff/video-bitrate-calculator.html";

            // This opens the default web browser
            Process.Start(url);
        }

        private void btnRaw_Click(object sender, EventArgs e) => ApplyPreset(24.0, true);
        private void btnMP4_Click(object sender, EventArgs e) => ApplyPreset(0.25, false);
        private void btnH264baseline_Click(object sender, EventArgs e) => ApplyPreset(0.13, false);
        private void btnH264high_Click(object sender, EventArgs e) => ApplyPreset(0.11, false);
        private void btnH265Main_Click(object sender, EventArgs e) => ApplyPreset(0.075, false);

        #endregion
        // --- EMPTY STUBS TO FIX DESIGNER ERRORS ---
        private void Form1_Load(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void label20_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void Seconds_TextChanged(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void txtTotalbitrate_TextChanged(object sender, EventArgs e) { }
        private void txtWidth_TextChanged(object sender, EventArgs e)
        {

        }
    }
}