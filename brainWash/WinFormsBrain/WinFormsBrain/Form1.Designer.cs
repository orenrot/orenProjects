
namespace WinFormBrainWash
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKnown = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLang = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.btnWordCount = new System.Windows.Forms.Button();
            this.comboLang = new System.Windows.Forms.ComboBox();
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.comboWordCount = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.btnTrans = new System.Windows.Forms.Button();
            this.btnTrans2 = new System.Windows.Forms.Button();
            this.btnTrans3 = new System.Windows.Forms.Button();
            this.btnTrans4 = new System.Windows.Forms.Button();
            this.btnAgain = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WordScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtTrans = new System.Windows.Forms.TextBox();
            this.lblWord = new System.Windows.Forms.Label();
            this.lblTrans = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(454, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "oren Pys";
            // 
            // btnKnown
            // 
            this.btnKnown.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKnown.Location = new System.Drawing.Point(809, 62);
            this.btnKnown.Name = "btnKnown";
            this.btnKnown.Size = new System.Drawing.Size(166, 68);
            this.btnKnown.TabIndex = 1;
            this.btnKnown.Text = "update known";
            this.btnKnown.UseVisualStyleBackColor = true;
            this.btnKnown.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(824, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "if known word";
            // 
            // btnLang
            // 
            this.btnLang.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLang.Location = new System.Drawing.Point(27, 88);
            this.btnLang.Name = "btnLang";
            this.btnLang.Size = new System.Drawing.Size(127, 53);
            this.btnLang.TabIndex = 3;
            this.btnLang.Text = "Language";
            this.btnLang.UseVisualStyleBackColor = true;
            // 
            // btnUnit
            // 
            this.btnUnit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUnit.Location = new System.Drawing.Point(27, 160);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(127, 53);
            this.btnUnit.TabIndex = 4;
            this.btnUnit.Text = "unit";
            this.btnUnit.UseVisualStyleBackColor = true;
            // 
            // btnWordCount
            // 
            this.btnWordCount.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWordCount.Location = new System.Drawing.Point(27, 239);
            this.btnWordCount.Name = "btnWordCount";
            this.btnWordCount.Size = new System.Drawing.Size(127, 68);
            this.btnWordCount.TabIndex = 5;
            this.btnWordCount.Text = "How much words";
            this.btnWordCount.UseVisualStyleBackColor = true;
            // 
            // comboLang
            // 
            this.comboLang.FormattingEnabled = true;
            this.comboLang.Items.AddRange(new object[] {
            "Choose language",
            "hebrew",
            "english"});
            this.comboLang.Location = new System.Drawing.Point(172, 89);
            this.comboLang.Name = "comboLang";
            this.comboLang.Size = new System.Drawing.Size(121, 23);
            this.comboLang.TabIndex = 6;
            this.comboLang.SelectedIndexChanged += new System.EventHandler(this.comboLang_SelectedIndexChanged);
            // 
            // comboUnit
            // 
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Items.AddRange(new object[] {
            "Choose language",
            "hebrew",
            "english"});
            this.comboUnit.Location = new System.Drawing.Point(172, 169);
            this.comboUnit.Name = "comboUnit";
            this.comboUnit.Size = new System.Drawing.Size(121, 23);
            this.comboUnit.TabIndex = 7;
            this.comboUnit.SelectedIndexChanged += new System.EventHandler(this.comboUnit_SelectedIndexChanged);
            // 
            // comboWordCount
            // 
            this.comboWordCount.FormattingEnabled = true;
            this.comboWordCount.Items.AddRange(new object[] {
            "Choose language",
            "hebrew",
            "english"});
            this.comboWordCount.Location = new System.Drawing.Point(172, 258);
            this.comboWordCount.Name = "comboWordCount";
            this.comboWordCount.Size = new System.Drawing.Size(121, 23);
            this.comboWordCount.TabIndex = 8;
            this.comboWordCount.SelectedIndexChanged += new System.EventHandler(this.comboWordCount_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(191, 340);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 43);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnWord
            // 
            this.btnWord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWord.Location = new System.Drawing.Point(406, 81);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(153, 68);
            this.btnWord.TabIndex = 10;
            this.btnWord.Text = "Word";
            this.btnWord.UseVisualStyleBackColor = true;
            // 
            // btnTrans
            // 
            this.btnTrans.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTrans.Location = new System.Drawing.Point(406, 315);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(153, 68);
            this.btnTrans.TabIndex = 11;
            this.btnTrans.Text = "Translation";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            // 
            // btnTrans2
            // 
            this.btnTrans2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTrans2.Location = new System.Drawing.Point(406, 230);
            this.btnTrans2.Name = "btnTrans2";
            this.btnTrans2.Size = new System.Drawing.Size(153, 68);
            this.btnTrans2.TabIndex = 12;
            this.btnTrans2.UseVisualStyleBackColor = true;
            this.btnTrans2.Click += new System.EventHandler(this.btnTrans2_Click);
            // 
            // btnTrans3
            // 
            this.btnTrans3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTrans3.Location = new System.Drawing.Point(565, 230);
            this.btnTrans3.Name = "btnTrans3";
            this.btnTrans3.Size = new System.Drawing.Size(153, 68);
            this.btnTrans3.TabIndex = 13;
            this.btnTrans3.UseVisualStyleBackColor = true;
            this.btnTrans3.Click += new System.EventHandler(this.btnTrans3_Click);
            // 
            // btnTrans4
            // 
            this.btnTrans4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTrans4.Location = new System.Drawing.Point(565, 315);
            this.btnTrans4.Name = "btnTrans4";
            this.btnTrans4.Size = new System.Drawing.Size(153, 68);
            this.btnTrans4.TabIndex = 14;
            this.btnTrans4.UseVisualStyleBackColor = true;
            this.btnTrans4.Click += new System.EventHandler(this.btnTrans4_Click);
            // 
            // btnAgain
            // 
            this.btnAgain.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgain.Location = new System.Drawing.Point(475, 401);
            this.btnAgain.Name = "btnAgain";
            this.btnAgain.Size = new System.Drawing.Size(153, 68);
            this.btnAgain.TabIndex = 15;
            this.btnAgain.Text = "Click to play";
            this.btnAgain.UseVisualStyleBackColor = true;
            this.btnAgain.Click += new System.EventHandler(this.btnAgain_Click);
            // 
            // btnStop
            // 
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStop.Location = new System.Drawing.Point(191, 414);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 43);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WordScore
            // 
            this.WordScore.AutoSize = true;
            this.WordScore.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WordScore.Location = new System.Drawing.Point(41, 29);
            this.WordScore.Name = "WordScore";
            this.WordScore.Size = new System.Drawing.Size(73, 32);
            this.WordScore.TabIndex = 17;
            this.WordScore.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(548, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 32);
            this.label3.TabIndex = 18;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(747, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(301, 221);
            this.dataGridView1.TabIndex = 19;
            // 
            // btnAddWord
            // 
            this.btnAddWord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddWord.Location = new System.Drawing.Point(921, 475);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(127, 52);
            this.btnAddWord.TabIndex = 20;
            this.btnAddWord.Text = "add word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWord.Location = new System.Drawing.Point(766, 414);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(116, 35);
            this.txtWord.TabIndex = 21;
            // 
            // txtTrans
            // 
            this.txtTrans.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTrans.Location = new System.Drawing.Point(921, 414);
            this.txtTrans.Name = "txtTrans";
            this.txtTrans.Size = new System.Drawing.Size(137, 35);
            this.txtTrans.TabIndex = 22;
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWord.Location = new System.Drawing.Point(766, 375);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(59, 30);
            this.lblWord.TabIndex = 23;
            this.lblWord.Text = "word";
            // 
            // lblTrans
            // 
            this.lblTrans.AutoSize = true;
            this.lblTrans.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTrans.Location = new System.Drawing.Point(921, 375);
            this.lblTrans.Name = "lblTrans";
            this.lblTrans.Size = new System.Drawing.Size(111, 30);
            this.lblTrans.TabIndex = 24;
            this.lblTrans.Text = "translation";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 539);
            this.Controls.Add(this.lblTrans);
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.txtTrans);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.WordScore);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAgain);
            this.Controls.Add(this.btnTrans4);
            this.Controls.Add(this.btnTrans3);
            this.Controls.Add(this.btnTrans2);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.comboWordCount);
            this.Controls.Add(this.comboUnit);
            this.Controls.Add(this.comboLang);
            this.Controls.Add(this.btnWordCount);
            this.Controls.Add(this.btnUnit);
            this.Controls.Add(this.btnLang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnKnown);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKnown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLang;
        private System.Windows.Forms.Button btnUnit;
        private System.Windows.Forms.Button btnWordCount;
        private System.Windows.Forms.ComboBox comboLang;
        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.ComboBox comboWordCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Button btnTrans;
        private System.Windows.Forms.Button btnTrans2;
        private System.Windows.Forms.Button btnTrans3;
        private System.Windows.Forms.Button btnTrans4;
        private System.Windows.Forms.Button btnAgain;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label WordScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtTrans;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblTrans;
    }
}

