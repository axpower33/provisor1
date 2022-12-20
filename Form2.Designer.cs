
namespace WindowsFormsApp8
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.единицаИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контрагентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.номенклатураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.документыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приходнаяНакладнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расходнаяНакладнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приходнаяНакладнаяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.расходнаяНакладнаяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.приходрасходНоменклатурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оборотнаяВедомостьНоменклатураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.документыToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.единицаИзмеренияToolStripMenuItem,
            this.контрагентыToolStripMenuItem,
            this.номенклатураToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // единицаИзмеренияToolStripMenuItem
            // 
            this.единицаИзмеренияToolStripMenuItem.Name = "единицаИзмеренияToolStripMenuItem";
            this.единицаИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.единицаИзмеренияToolStripMenuItem.Text = "Единица измерения";
            this.единицаИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицаИзмеренияToolStripMenuItem_Click);
            // 
            // контрагентыToolStripMenuItem
            // 
            this.контрагентыToolStripMenuItem.Name = "контрагентыToolStripMenuItem";
            this.контрагентыToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.контрагентыToolStripMenuItem.Text = "Контрагенты";
            this.контрагентыToolStripMenuItem.Click += new System.EventHandler(this.контрагентыToolStripMenuItem_Click);
            // 
            // номенклатураToolStripMenuItem
            // 
            this.номенклатураToolStripMenuItem.Name = "номенклатураToolStripMenuItem";
            this.номенклатураToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.номенклатураToolStripMenuItem.Text = "Номенклатура";
            this.номенклатураToolStripMenuItem.Click += new System.EventHandler(this.номенклатураToolStripMenuItem_Click);
            // 
            // документыToolStripMenuItem
            // 
            this.документыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приходнаяНакладнаяToolStripMenuItem,
            this.расходнаяНакладнаяToolStripMenuItem});
            this.документыToolStripMenuItem.Name = "документыToolStripMenuItem";
            this.документыToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.документыToolStripMenuItem.Text = "Документы";
            // 
            // приходнаяНакладнаяToolStripMenuItem
            // 
            this.приходнаяНакладнаяToolStripMenuItem.Name = "приходнаяНакладнаяToolStripMenuItem";
            this.приходнаяНакладнаяToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.приходнаяНакладнаяToolStripMenuItem.Text = "Приходная накладная";
            this.приходнаяНакладнаяToolStripMenuItem.Click += new System.EventHandler(this.приходнаяНакладнаяToolStripMenuItem_Click);
            // 
            // расходнаяНакладнаяToolStripMenuItem
            // 
            this.расходнаяНакладнаяToolStripMenuItem.Name = "расходнаяНакладнаяToolStripMenuItem";
            this.расходнаяНакладнаяToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.расходнаяНакладнаяToolStripMenuItem.Text = "Расходная накладная";
            this.расходнаяНакладнаяToolStripMenuItem.Click += new System.EventHandler(this.расходнаяНакладнаяToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.приходнаяНакладнаяToolStripMenuItem1,
            this.расходнаяНакладнаяToolStripMenuItem1,
            this.приходрасходНоменклатурыToolStripMenuItem,
            this.оборотнаяВедомостьНоменклатураToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // приходнаяНакладнаяToolStripMenuItem1
            // 
            this.приходнаяНакладнаяToolStripMenuItem1.Name = "приходнаяНакладнаяToolStripMenuItem1";
            this.приходнаяНакладнаяToolStripMenuItem1.Size = new System.Drawing.Size(252, 22);
            this.приходнаяНакладнаяToolStripMenuItem1.Text = "Приходная накладная";
            this.приходнаяНакладнаяToolStripMenuItem1.Click += new System.EventHandler(this.приходнаяНакладнаяToolStripMenuItem1_Click);
            // 
            // расходнаяНакладнаяToolStripMenuItem1
            // 
            this.расходнаяНакладнаяToolStripMenuItem1.Name = "расходнаяНакладнаяToolStripMenuItem1";
            this.расходнаяНакладнаяToolStripMenuItem1.Size = new System.Drawing.Size(252, 22);
            this.расходнаяНакладнаяToolStripMenuItem1.Text = "Расходная накладная";
            this.расходнаяНакладнаяToolStripMenuItem1.Click += new System.EventHandler(this.расходнаяНакладнаяToolStripMenuItem1_Click);
            // 
            // приходрасходНоменклатурыToolStripMenuItem
            // 
            this.приходрасходНоменклатурыToolStripMenuItem.Name = "приходрасходНоменклатурыToolStripMenuItem";
            this.приходрасходНоменклатурыToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.приходрасходНоменклатурыToolStripMenuItem.Text = "Приход/расход номенклатуры";
            this.приходрасходНоменклатурыToolStripMenuItem.Click += new System.EventHandler(this.приходрасходНоменклатурыToolStripMenuItem_Click);
            // 
            // оборотнаяВедомостьНоменклатураToolStripMenuItem
            // 
            this.оборотнаяВедомостьНоменклатураToolStripMenuItem.Name = "оборотнаяВедомостьНоменклатураToolStripMenuItem";
            this.оборотнаяВедомостьНоменклатураToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.оборотнаяВедомостьНоменклатураToolStripMenuItem.Text = "Оборотно-сальдовая ведомость";
            this.оборотнаяВедомостьНоменклатураToolStripMenuItem.Click += new System.EventHandler(this.оборотнаяВедомостьНоменклатураToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(80, 40);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem единицаИзмеренияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контрагентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem номенклатураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem документыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приходнаяНакладнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приходнаяНакладнаяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem расходнаяНакладнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem расходнаяНакладнаяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem приходрасходНоменклатурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оборотнаяВедомостьНоменклатураToolStripMenuItem;
    }
}