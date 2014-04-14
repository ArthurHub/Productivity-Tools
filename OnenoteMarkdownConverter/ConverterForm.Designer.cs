namespace OnenoteMarkdownConverter
{
    partial class ConverterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._markdownTextBox = new System.Windows.Forms.TextBox();
            this._copyButton = new System.Windows.Forms.Button();
            this._convertButton = new System.Windows.Forms.Button();
            this._htmlTextBox = new OnenoteMarkdownConverter.HtmlTextboxcs();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainer
            // 
            this._splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer.Location = new System.Drawing.Point(0, 53);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._htmlTextBox);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._markdownTextBox);
            this._splitContainer.Size = new System.Drawing.Size(700, 597);
            this._splitContainer.SplitterDistance = 339;
            this._splitContainer.TabIndex = 0;
            // 
            // _markdownTextBox
            // 
            this._markdownTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._markdownTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._markdownTextBox.Location = new System.Drawing.Point(0, 0);
            this._markdownTextBox.Multiline = true;
            this._markdownTextBox.Name = "_markdownTextBox";
            this._markdownTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._markdownTextBox.Size = new System.Drawing.Size(357, 597);
            this._markdownTextBox.TabIndex = 0;
            this._markdownTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTextBox_KeyPress);
            // 
            // _copyButton
            // 
            this._copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._copyButton.Location = new System.Drawing.Point(620, 24);
            this._copyButton.Name = "_copyButton";
            this._copyButton.Size = new System.Drawing.Size(75, 23);
            this._copyButton.TabIndex = 1;
            this._copyButton.Text = "Copy";
            this._copyButton.UseVisualStyleBackColor = true;
            this._copyButton.Click += new System.EventHandler(this.OnCopyButton_Click);
            // 
            // _convertButton
            // 
            this._convertButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this._convertButton.Location = new System.Drawing.Point(188, 24);
            this._convertButton.Name = "_convertButton";
            this._convertButton.Size = new System.Drawing.Size(151, 23);
            this._convertButton.TabIndex = 2;
            this._convertButton.Text = "Convert from Clipboard";
            this._convertButton.UseVisualStyleBackColor = true;
            this._convertButton.Click += new System.EventHandler(this.OnConvertButton_Click);
            // 
            // _htmlTextBox
            // 
            this._htmlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._htmlTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._htmlTextBox.Location = new System.Drawing.Point(0, 0);
            this._htmlTextBox.Multiline = true;
            this._htmlTextBox.Name = "_htmlTextBox";
            this._htmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._htmlTextBox.Size = new System.Drawing.Size(339, 597);
            this._htmlTextBox.TabIndex = 0;
            this._htmlTextBox.TextChanged += new System.EventHandler(this.OnHtmlTextBox_TextChanged);
            this._htmlTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTextBox_KeyPress);
            // 
            // ConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 650);
            this.Controls.Add(this._convertButton);
            this.Controls.Add(this._copyButton);
            this.Controls.Add(this._splitContainer);
            this.Name = "ConverterForm";
            this.Text = "OneNote Markdown Converter";
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel1.PerformLayout();
            this._splitContainer.Panel2.ResumeLayout(false);
            this._splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.TextBox _markdownTextBox;
        private HtmlTextboxcs _htmlTextBox;
        private System.Windows.Forms.Button _copyButton;
        private System.Windows.Forms.Button _convertButton;
    }
}

