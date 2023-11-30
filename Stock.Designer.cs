namespace Trabajo_grupal_programacion_y_estructuras_de_datos
{
    partial class Stock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAgregarProducto = new Guna.UI2.WinForms.Guna2Button();
            this.txtProducto = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrecio = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgProductos = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIDADES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.txtEliminarProducto = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BorderRadius = 5;
            this.btnAgregarProducto.CheckedState.Parent = this.btnAgregarProducto;
            this.btnAgregarProducto.CustomImages.Parent = this.btnAgregarProducto;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgregarProducto.ForeColor = System.Drawing.Color.White;
            this.btnAgregarProducto.HoverState.Parent = this.btnAgregarProducto;
            this.btnAgregarProducto.Location = new System.Drawing.Point(54, 249);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.ShadowDecoration.Parent = this.btnAgregarProducto;
            this.btnAgregarProducto.Size = new System.Drawing.Size(125, 40);
            this.btnAgregarProducto.TabIndex = 1;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.BorderRadius = 5;
            this.txtProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProducto.DefaultText = "";
            this.txtProducto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProducto.DisabledState.Parent = this.txtProducto;
            this.txtProducto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProducto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProducto.FocusedState.Parent = this.txtProducto;
            this.txtProducto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProducto.HoverState.Parent = this.txtProducto;
            this.txtProducto.Location = new System.Drawing.Point(30, 165);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.PasswordChar = '\0';
            this.txtProducto.PlaceholderText = "Nombre de Producto";
            this.txtProducto.SelectedText = "";
            this.txtProducto.ShadowDecoration.Parent = this.txtProducto;
            this.txtProducto.Size = new System.Drawing.Size(184, 36);
            this.txtProducto.TabIndex = 2;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BorderRadius = 5;
            this.txtPrecio.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrecio.DefaultText = "";
            this.txtPrecio.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrecio.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrecio.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecio.DisabledState.Parent = this.txtPrecio;
            this.txtPrecio.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrecio.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecio.FocusedState.Parent = this.txtPrecio;
            this.txtPrecio.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrecio.HoverState.Parent = this.txtPrecio;
            this.txtPrecio.Location = new System.Drawing.Point(30, 207);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PasswordChar = '\0';
            this.txtPrecio.PlaceholderText = "Precio";
            this.txtPrecio.SelectedText = "";
            this.txtPrecio.ShadowDecoration.Parent = this.txtPrecio;
            this.txtPrecio.Size = new System.Drawing.Size(184, 36);
            this.txtPrecio.TabIndex = 3;
            // 
            // dgProductos
            // 
            this.dgProductos.AllowUserToAddRows = false;
            this.dgProductos.AllowUserToDeleteRows = false;
            this.dgProductos.AllowUserToResizeColumns = false;
            this.dgProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PRODUCTO,
            this.PRECIO,
            this.UNIDADES});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgProductos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgProductos.EnableHeadersVisualStyles = false;
            this.dgProductos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgProductos.Location = new System.Drawing.Point(255, 72);
            this.dgProductos.Name = "dgProductos";
            this.dgProductos.ReadOnly = true;
            this.dgProductos.RowHeadersVisible = false;
            this.dgProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProductos.Size = new System.Drawing.Size(512, 322);
            this.dgProductos.TabIndex = 4;
            this.dgProductos.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgProductos.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgProductos.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgProductos.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgProductos.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgProductos.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgProductos.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgProductos.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgProductos.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgProductos.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgProductos.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgProductos.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgProductos.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgProductos.ThemeStyle.HeaderStyle.Height = 23;
            this.dgProductos.ThemeStyle.ReadOnly = true;
            this.dgProductos.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgProductos.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgProductos.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgProductos.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgProductos.ThemeStyle.RowsStyle.Height = 22;
            this.dgProductos.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgProductos.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ID
            // 
            this.ID.FillWeight = 81.21828F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PRODUCTO
            // 
            this.PRODUCTO.FillWeight = 165.3853F;
            this.PRODUCTO.HeaderText = "PRODUCTO";
            this.PRODUCTO.Name = "PRODUCTO";
            this.PRODUCTO.ReadOnly = true;
            this.PRODUCTO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PRECIO
            // 
            this.PRECIO.FillWeight = 68.04394F;
            this.PRECIO.HeaderText = "PRECIO";
            this.PRECIO.Name = "PRECIO";
            this.PRECIO.ReadOnly = true;
            this.PRECIO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UNIDADES
            // 
            this.UNIDADES.FillWeight = 85.35248F;
            this.UNIDADES.HeaderText = "UNIDADES";
            this.UNIDADES.Name = "UNIDADES";
            this.UNIDADES.ReadOnly = true;
            this.UNIDADES.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(54, 295);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(125, 40);
            this.guna2Button1.TabIndex = 5;
            this.guna2Button1.Text = "Editar";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.CheckedState.Parent = this.guna2Button2;
            this.guna2Button2.CustomImages.Parent = this.guna2Button2;
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Parent = this.guna2Button2;
            this.guna2Button2.Location = new System.Drawing.Point(54, 448);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.ShadowDecoration.Parent = this.guna2Button2;
            this.guna2Button2.Size = new System.Drawing.Size(125, 40);
            this.guna2Button2.TabIndex = 6;
            this.guna2Button2.Text = "Eliminar";
            // 
            // txtEliminarProducto
            // 
            this.txtEliminarProducto.BorderRadius = 5;
            this.txtEliminarProducto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEliminarProducto.DefaultText = "";
            this.txtEliminarProducto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEliminarProducto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEliminarProducto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEliminarProducto.DisabledState.Parent = this.txtEliminarProducto;
            this.txtEliminarProducto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEliminarProducto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEliminarProducto.FocusedState.Parent = this.txtEliminarProducto;
            this.txtEliminarProducto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEliminarProducto.HoverState.Parent = this.txtEliminarProducto;
            this.txtEliminarProducto.Location = new System.Drawing.Point(30, 406);
            this.txtEliminarProducto.Name = "txtEliminarProducto";
            this.txtEliminarProducto.PasswordChar = '\0';
            this.txtEliminarProducto.PlaceholderText = "Id";
            this.txtEliminarProducto.SelectedText = "";
            this.txtEliminarProducto.ShadowDecoration.Parent = this.txtEliminarProducto;
            this.txtEliminarProducto.Size = new System.Drawing.Size(184, 36);
            this.txtEliminarProducto.TabIndex = 7;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 500);
            this.Controls.Add(this.txtEliminarProducto);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.dgProductos);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.btnAgregarProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stock";
            this.Text = "Stock";
            this.Load += new System.EventHandler(this.Stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnAgregarProducto;
        private Guna.UI2.WinForms.Guna2TextBox txtProducto;
        private Guna.UI2.WinForms.Guna2TextBox txtPrecio;
        private Guna.UI2.WinForms.Guna2DataGridView dgProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIDADES;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2TextBox txtEliminarProducto;
    }
}