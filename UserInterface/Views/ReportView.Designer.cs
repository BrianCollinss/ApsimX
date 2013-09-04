﻿namespace UserInterface.Views
{
    partial class ReportView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VariableEditor = new Utility.Editor();
            this.FrequencyEditor = new Utility.Editor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.VariableEditor);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FrequencyEditor);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(606, 487);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Reporting frequency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Reporting variables:";
            // 
            // VariableEditor
            // 
            this.VariableEditor.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.VariableEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableEditor.Lines = new string[0];
            this.VariableEditor.Location = new System.Drawing.Point(0, 13);
            this.VariableEditor.Name = "VariableEditor";
            this.VariableEditor.Size = new System.Drawing.Size(606, 308);
            this.VariableEditor.TabIndex = 6;
            this.VariableEditor.ContextItemsNeeded += new System.EventHandler<Utility.Editor.NeedContextItems>(this.OnVariableListNeedItems);
            this.VariableEditor.TextHasChangedByUser += new System.EventHandler(this.OnVariableListChanged);
            // 
            // FrequencyEditor
            // 
            this.FrequencyEditor.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.FrequencyEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrequencyEditor.Lines = new string[0];
            this.FrequencyEditor.Location = new System.Drawing.Point(0, 13);
            this.FrequencyEditor.Name = "FrequencyEditor";
            this.FrequencyEditor.Size = new System.Drawing.Size(606, 149);
            this.FrequencyEditor.TabIndex = 7;
            this.FrequencyEditor.ContextItemsNeeded += new System.EventHandler<Utility.Editor.NeedContextItems>(this.OnEventListNeedItems);
            this.FrequencyEditor.TextHasChangedByUser += new System.EventHandler(this.OnEventListChanged);
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(606, 487);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Utility.Editor VariableEditor;
        private Utility.Editor FrequencyEditor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;


    }
}