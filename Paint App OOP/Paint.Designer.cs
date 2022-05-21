
namespace Paint_App_OOP
{
    partial class Paint
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
            this.panel_tools = new System.Windows.Forms.Panel();
            this.bar_thickness = new System.Windows.Forms.TrackBar();
            this.panel_colorpicker = new System.Windows.Forms.PictureBox();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_rectangle = new System.Windows.Forms.Button();
            this.btn_circle = new System.Windows.Forms.Button();
            this.btn_eraser = new System.Windows.Forms.Button();
            this.btn_pencil = new System.Windows.Forms.Button();
            this.btn_fill = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.btn_selected = new System.Windows.Forms.Button();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel_board = new System.Windows.Forms.PictureBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.panel_tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar_thickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_colorpicker)).BeginInit();
            this.panel_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_board)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_tools
            // 
            this.panel_tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_tools.Controls.Add(this.bar_thickness);
            this.panel_tools.Controls.Add(this.panel_colorpicker);
            this.panel_tools.Controls.Add(this.btn_line);
            this.panel_tools.Controls.Add(this.btn_rectangle);
            this.panel_tools.Controls.Add(this.btn_circle);
            this.panel_tools.Controls.Add(this.btn_eraser);
            this.panel_tools.Controls.Add(this.btn_pencil);
            this.panel_tools.Controls.Add(this.btn_fill);
            this.panel_tools.Controls.Add(this.btn_color);
            this.panel_tools.Controls.Add(this.btn_selected);
            this.panel_tools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_tools.Location = new System.Drawing.Point(0, 0);
            this.panel_tools.Name = "panel_tools";
            this.panel_tools.Size = new System.Drawing.Size(784, 124);
            this.panel_tools.TabIndex = 0;
            // 
            // bar_thickness
            // 
            this.bar_thickness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bar_thickness.Location = new System.Drawing.Point(288, 79);
            this.bar_thickness.Minimum = 1;
            this.bar_thickness.Name = "bar_thickness";
            this.bar_thickness.Size = new System.Drawing.Size(484, 45);
            this.bar_thickness.TabIndex = 3;
            this.bar_thickness.Value = 1;
            this.bar_thickness.Scroll += new System.EventHandler(this.bar_thickness_Scroll);
            // 
            // panel_colorpicker
            // 
            this.panel_colorpicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_colorpicker.Image = global::Paint_App_OOP.Properties.Resources.color_palette;
            this.panel_colorpicker.Location = new System.Drawing.Point(3, 3);
            this.panel_colorpicker.Name = "panel_colorpicker";
            this.panel_colorpicker.Size = new System.Drawing.Size(238, 118);
            this.panel_colorpicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.panel_colorpicker.TabIndex = 3;
            this.panel_colorpicker.TabStop = false;
            this.panel_colorpicker.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_colorpicker_MouseClick);
            // 
            // btn_line
            // 
            this.btn_line.BackgroundImage = global::Paint_App_OOP.Properties.Resources.line;
            this.btn_line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_line.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_line.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_line.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_line.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_line.ForeColor = System.Drawing.Color.White;
            this.btn_line.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_line.Location = new System.Drawing.Point(708, 13);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(64, 64);
            this.btn_line.TabIndex = 7;
            this.btn_line.Text = "Line";
            this.btn_line.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_rectangle
            // 
            this.btn_rectangle.BackgroundImage = global::Paint_App_OOP.Properties.Resources.rectangle;
            this.btn_rectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_rectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_rectangle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_rectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_rectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rectangle.ForeColor = System.Drawing.Color.White;
            this.btn_rectangle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_rectangle.Location = new System.Drawing.Point(638, 13);
            this.btn_rectangle.Name = "btn_rectangle";
            this.btn_rectangle.Size = new System.Drawing.Size(64, 64);
            this.btn_rectangle.TabIndex = 6;
            this.btn_rectangle.Text = "Rectangle";
            this.btn_rectangle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_rectangle.UseVisualStyleBackColor = true;
            this.btn_rectangle.Click += new System.EventHandler(this.btn_rectangle_Click);
            // 
            // btn_circle
            // 
            this.btn_circle.BackgroundImage = global::Paint_App_OOP.Properties.Resources.circle;
            this.btn_circle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_circle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_circle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_circle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_circle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_circle.ForeColor = System.Drawing.Color.White;
            this.btn_circle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_circle.Location = new System.Drawing.Point(568, 13);
            this.btn_circle.Name = "btn_circle";
            this.btn_circle.Size = new System.Drawing.Size(64, 64);
            this.btn_circle.TabIndex = 5;
            this.btn_circle.Text = "Circle";
            this.btn_circle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_circle.UseVisualStyleBackColor = true;
            this.btn_circle.Click += new System.EventHandler(this.btn_circle_Click);
            // 
            // btn_eraser
            // 
            this.btn_eraser.BackgroundImage = global::Paint_App_OOP.Properties.Resources.eraser;
            this.btn_eraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_eraser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_eraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_eraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eraser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eraser.ForeColor = System.Drawing.Color.White;
            this.btn_eraser.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_eraser.Location = new System.Drawing.Point(498, 13);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(64, 64);
            this.btn_eraser.TabIndex = 4;
            this.btn_eraser.Text = "Eraser";
            this.btn_eraser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eraser.UseVisualStyleBackColor = true;
            this.btn_eraser.Click += new System.EventHandler(this.btn_eraser_Click);
            // 
            // btn_pencil
            // 
            this.btn_pencil.BackgroundImage = global::Paint_App_OOP.Properties.Resources.pencil;
            this.btn_pencil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_pencil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pencil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_pencil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_pencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pencil.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pencil.ForeColor = System.Drawing.Color.White;
            this.btn_pencil.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_pencil.Location = new System.Drawing.Point(428, 13);
            this.btn_pencil.Name = "btn_pencil";
            this.btn_pencil.Size = new System.Drawing.Size(64, 64);
            this.btn_pencil.TabIndex = 3;
            this.btn_pencil.Text = "Pencil";
            this.btn_pencil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pencil.UseVisualStyleBackColor = true;
            this.btn_pencil.Click += new System.EventHandler(this.btn_pencil_Click);
            // 
            // btn_fill
            // 
            this.btn_fill.BackgroundImage = global::Paint_App_OOP.Properties.Resources.bucket;
            this.btn_fill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_fill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_fill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_fill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fill.ForeColor = System.Drawing.Color.White;
            this.btn_fill.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_fill.Location = new System.Drawing.Point(358, 13);
            this.btn_fill.Name = "btn_fill";
            this.btn_fill.Size = new System.Drawing.Size(64, 64);
            this.btn_fill.TabIndex = 2;
            this.btn_fill.Text = "Fill";
            this.btn_fill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_fill.UseVisualStyleBackColor = true;
            this.btn_fill.Click += new System.EventHandler(this.btn_fill_Click);
            // 
            // btn_color
            // 
            this.btn_color.BackgroundImage = global::Paint_App_OOP.Properties.Resources.cursor__1_;
            this.btn_color.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_color.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_color.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_color.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_color.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_color.ForeColor = System.Drawing.Color.White;
            this.btn_color.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_color.Location = new System.Drawing.Point(288, 13);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(64, 64);
            this.btn_color.TabIndex = 1;
            this.btn_color.Text = "Move";
            this.btn_color.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // btn_selected
            // 
            this.btn_selected.BackColor = System.Drawing.Color.White;
            this.btn_selected.Location = new System.Drawing.Point(247, 29);
            this.btn_selected.Name = "btn_selected";
            this.btn_selected.Size = new System.Drawing.Size(35, 33);
            this.btn_selected.TabIndex = 0;
            this.btn_selected.UseVisualStyleBackColor = false;
            // 
            // panel_bottom
            // 
            this.panel_bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_bottom.Controls.Add(this.btn_exit);
            this.panel_bottom.Controls.Add(this.btn_clear);
            this.panel_bottom.Controls.Add(this.btn_load);
            this.panel_bottom.Controls.Add(this.btn_save);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 460);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(784, 51);
            this.panel_bottom.TabIndex = 1;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(697, 16);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(94, 16);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(75, 23);
            this.btn_load.TabIndex = 1;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(13, 16);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // panel_board
            // 
            this.panel_board.BackColor = System.Drawing.Color.White;
            this.panel_board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_board.Location = new System.Drawing.Point(0, 0);
            this.panel_board.Name = "panel_board";
            this.panel_board.Size = new System.Drawing.Size(784, 511);
            this.panel_board.TabIndex = 2;
            this.panel_board.TabStop = false;
            this.panel_board.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_board_Paint);
            this.panel_board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_board_MouseClick);
            this.panel_board.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_board_MouseDown);
            this.panel_board.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_board_MouseMove);
            this.panel_board.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_board_MouseUp);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(616, 16);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel_tools);
            this.Controls.Add(this.panel_board);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel_tools.ResumeLayout(false);
            this.panel_tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar_thickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel_colorpicker)).EndInit();
            this.panel_bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_tools;
        private System.Windows.Forms.Button btn_line;
        private System.Windows.Forms.Button btn_rectangle;
        private System.Windows.Forms.Button btn_circle;
        private System.Windows.Forms.Button btn_eraser;
        private System.Windows.Forms.Button btn_pencil;
        private System.Windows.Forms.Button btn_fill;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_selected;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.PictureBox panel_board;
        private System.Windows.Forms.PictureBox panel_colorpicker;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TrackBar bar_thickness;
        private System.Windows.Forms.Button btn_clear;
    }
}

