namespace HtmlObfuscator
{
    partial class HtmlObfuscator
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
            this._sourceHtmlTB = new System.Windows.Forms.TextBox();
            this._obfuscatedHtmlTB = new System.Windows.Forms.TextBox();
            this._pasteHtmlButton = new System.Windows.Forms.Button();
            this._copyHtmlButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._splitContainer.Location = new System.Drawing.Point(0, 41);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._sourceHtmlTB);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._obfuscatedHtmlTB);
            this._splitContainer.Size = new System.Drawing.Size(686, 553);
            this._splitContainer.SplitterDistance = 342;
            this._splitContainer.TabIndex = 0;
            // 
            // _sourceHtmlTB
            // 
            this._sourceHtmlTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sourceHtmlTB.Location = new System.Drawing.Point(0, 0);
            this._sourceHtmlTB.Multiline = true;
            this._sourceHtmlTB.Name = "_sourceHtmlTB";
            this._sourceHtmlTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._sourceHtmlTB.Size = new System.Drawing.Size(342, 553);
            this._sourceHtmlTB.TabIndex = 0;
            this._sourceHtmlTB.TextChanged += new System.EventHandler(this.OnSourceHtml_TextChanged);
            // 
            // _obfuscatedHtmlTB
            // 
            this._obfuscatedHtmlTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._obfuscatedHtmlTB.Location = new System.Drawing.Point(0, 0);
            this._obfuscatedHtmlTB.Multiline = true;
            this._obfuscatedHtmlTB.Name = "_obfuscatedHtmlTB";
            this._obfuscatedHtmlTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._obfuscatedHtmlTB.Size = new System.Drawing.Size(340, 553);
            this._obfuscatedHtmlTB.TabIndex = 1;
            // 
            // _pasteHtmlButton
            // 
            this._pasteHtmlButton.Location = new System.Drawing.Point(267, 12);
            this._pasteHtmlButton.Name = "_pasteHtmlButton";
            this._pasteHtmlButton.Size = new System.Drawing.Size(75, 23);
            this._pasteHtmlButton.TabIndex = 1;
            this._pasteHtmlButton.Text = "paste";
            this._pasteHtmlButton.UseVisualStyleBackColor = true;
            this._pasteHtmlButton.Click += new System.EventHandler(this.OnPasteHtmlButton_Click);
            // 
            // _copyHtmlButton
            // 
            this._copyHtmlButton.Location = new System.Drawing.Point(605, 12);
            this._copyHtmlButton.Name = "_copyHtmlButton";
            this._copyHtmlButton.Size = new System.Drawing.Size(75, 23);
            this._copyHtmlButton.TabIndex = 2;
            this._copyHtmlButton.Text = "copy";
            this._copyHtmlButton.UseVisualStyleBackColor = true;
            this._copyHtmlButton.Click += new System.EventHandler(this.OnCopyHtmlButton_Click);
            // 
            // HtmlObfuscator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 594);
            this.Controls.Add(this._copyHtmlButton);
            this.Controls.Add(this._pasteHtmlButton);
            this.Controls.Add(this._splitContainer);
            this.Name = "HtmlObfuscator";
            this.Text = "Html Obfuscator";
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
        private System.Windows.Forms.TextBox _sourceHtmlTB;
        private System.Windows.Forms.TextBox _obfuscatedHtmlTB;
        private System.Windows.Forms.Button _pasteHtmlButton;
        private System.Windows.Forms.Button _copyHtmlButton;
    }
}

