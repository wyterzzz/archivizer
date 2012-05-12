namespace Archivizor_Project
{
    partial class SearchForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.searchListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deselectAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addSelectedItemsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchListView
            // 
            this.searchListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.type,
            this.fullPath,
            this.size});
            this.searchListView.ContextMenuStrip = this.contextMenuStrip1;
            this.searchListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchListView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchListView.FullRowSelect = true;
            this.searchListView.Location = new System.Drawing.Point(0, 0);
            this.searchListView.Name = "searchListView";
            this.searchListView.Size = new System.Drawing.Size(596, 212);
            this.searchListView.SmallImageList = this.imageList;
            this.searchListView.TabIndex = 0;
            this.searchListView.UseCompatibleStateImageBehavior = false;
            this.searchListView.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 110;
            // 
            // type
            // 
            this.type.Text = "Type";
            this.type.Width = 97;
            // 
            // fullPath
            // 
            this.fullPath.Text = "Full Path";
            this.fullPath.Width = 277;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 92;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllItemsToolStripMenuItem,
            this.deselectAllItemsToolStripMenuItem,
            this.toolStripSeparator1,
            this.addSelectedItemsToToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 98);
            // 
            // selectAllItemsToolStripMenuItem
            // 
            this.selectAllItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectAllItemsToolStripMenuItem.Image")));
            this.selectAllItemsToolStripMenuItem.Name = "selectAllItemsToolStripMenuItem";
            this.selectAllItemsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.selectAllItemsToolStripMenuItem.Text = "Select all items";
            this.selectAllItemsToolStripMenuItem.Click += new System.EventHandler(this.selectAllItemsToolStripMenuItem_Click);
            // 
            // deselectAllItemsToolStripMenuItem
            // 
            this.deselectAllItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deselectAllItemsToolStripMenuItem.Image")));
            this.deselectAllItemsToolStripMenuItem.Name = "deselectAllItemsToolStripMenuItem";
            this.deselectAllItemsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.deselectAllItemsToolStripMenuItem.Text = "Deselect all items";
            this.deselectAllItemsToolStripMenuItem.Click += new System.EventHandler(this.deselectAllItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // addSelectedItemsToToolStripMenuItem
            // 
            this.addSelectedItemsToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archiveToolStripMenuItem,
            this.extractManagerToolStripMenuItem});
            this.addSelectedItemsToToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addSelectedItemsToToolStripMenuItem.Image")));
            this.addSelectedItemsToToolStripMenuItem.Name = "addSelectedItemsToToolStripMenuItem";
            this.addSelectedItemsToToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addSelectedItemsToToolStripMenuItem.Text = "Add files to...";
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archiveToolStripMenuItem.Image")));
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.archiveToolStripMenuItem.Text = "Archive";
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiveToolStripMenuItem_Click);
            // 
            // extractManagerToolStripMenuItem
            // 
            this.extractManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("extractManagerToolStripMenuItem.Image")));
            this.extractManagerToolStripMenuItem.Name = "extractManagerToolStripMenuItem";
            this.extractManagerToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.extractManagerToolStripMenuItem.Text = "Extract Manager";
            this.extractManagerToolStripMenuItem.Click += new System.EventHandler(this.extractManagerToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 212);
            this.Controls.Add(this.searchListView);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView searchListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectAllItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deselectAllItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addSelectedItemsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractManagerToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader type;
        private System.Windows.Forms.ColumnHeader fullPath;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ImageList imageList;
    }
}