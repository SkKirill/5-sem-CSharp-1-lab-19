using System.ComponentModel;

namespace Comparable_Mark.Forms;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
		panelStudents = new Panel();
		menuStrip1 = new MenuStrip();
		fileToolStripMenuItem = new ToolStripMenuItem();
		newToolStripMenuItem = new ToolStripMenuItem();
		openToolStripMenuItem = new ToolStripMenuItem();
		saveToolStripMenuItem = new ToolStripMenuItem();
		saveAsToolStripMenuItem = new ToolStripMenuItem();
		clearToolStripMenuItem = new ToolStripMenuItem();
		runTaskToolStripMenuItem = new ToolStripMenuItem();
		propertyToolStripMenuItem = new ToolStripMenuItem();
		menuStrip1.SuspendLayout();
		SuspendLayout();
		// 
		// panelStudents
		// 
		panelStudents.Location = new Point(12, 63);
		panelStudents.Name = "panelStudents";
		panelStudents.Size = new Size(551, 238);
		panelStudents.TabIndex = 0;
		// 
		// menuStrip1
		// 
		menuStrip1.ImageScalingSize = new Size(20, 20);
		menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, runTaskToolStripMenuItem, propertyToolStripMenuItem });
		menuStrip1.Location = new Point(0, 0);
		menuStrip1.Name = "menuStrip1";
		menuStrip1.Size = new Size(1060, 28);
		menuStrip1.TabIndex = 1;
		menuStrip1.Text = "menuStrip1";
		// 
		// fileToolStripMenuItem
		// 
		fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, clearToolStripMenuItem });
		fileToolStripMenuItem.Name = "fileToolStripMenuItem";
		fileToolStripMenuItem.Size = new Size(46, 24);
		fileToolStripMenuItem.Text = "File";
		// 
		// newToolStripMenuItem
		// 
		newToolStripMenuItem.Name = "newToolStripMenuItem";
		newToolStripMenuItem.Size = new Size(141, 26);
		newToolStripMenuItem.Text = "New";
		// 
		// openToolStripMenuItem
		// 
		openToolStripMenuItem.Name = "openToolStripMenuItem";
		openToolStripMenuItem.Size = new Size(141, 26);
		openToolStripMenuItem.Text = "Open";
		// 
		// saveToolStripMenuItem
		// 
		saveToolStripMenuItem.Name = "saveToolStripMenuItem";
		saveToolStripMenuItem.Size = new Size(141, 26);
		saveToolStripMenuItem.Text = "Save";
		// 
		// saveAsToolStripMenuItem
		// 
		saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
		saveAsToolStripMenuItem.Size = new Size(141, 26);
		saveAsToolStripMenuItem.Text = "Save as";
		// 
		// clearToolStripMenuItem
		// 
		clearToolStripMenuItem.Name = "clearToolStripMenuItem";
		clearToolStripMenuItem.Size = new Size(141, 26);
		clearToolStripMenuItem.Text = "Clear";
		// 
		// runTaskToolStripMenuItem
		// 
		runTaskToolStripMenuItem.Name = "runTaskToolStripMenuItem";
		runTaskToolStripMenuItem.Size = new Size(75, 24);
		runTaskToolStripMenuItem.Text = "RunTask";
		// 
		// propertyToolStripMenuItem
		// 
		propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
		propertyToolStripMenuItem.Size = new Size(79, 24);
		propertyToolStripMenuItem.Text = "Property";
		// 
		// MainForm
		// 
		AutoScaleDimensions = new SizeF(8F, 20F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(1060, 500);
		Controls.Add(panelStudents);
		Controls.Add(menuStrip1);
		MainMenuStrip = menuStrip1;
		Name = "MainForm";
		Text = "MainForm";
		Resize += MainForm_Resize;
		menuStrip1.ResumeLayout(false);
		menuStrip1.PerformLayout();
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Panel panelStudents;
	private Label label1;
	private MenuStrip menuStrip1;
	private ToolStripMenuItem fileToolStripMenuItem;
	private ToolStripMenuItem newToolStripMenuItem;
	private ToolStripMenuItem openToolStripMenuItem;
	private ToolStripMenuItem saveToolStripMenuItem;
	private ToolStripMenuItem saveAsToolStripMenuItem;
	private ToolStripMenuItem clearToolStripMenuItem;
	private ToolStripMenuItem runTaskToolStripMenuItem;
	private ToolStripMenuItem propertyToolStripMenuItem;
}