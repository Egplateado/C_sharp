namespace capa_presentacion
{
    partial class fr_clientes
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtId = new NumericUpDown();
            lnkfoto = new LinkLabel();
            picFoto = new PictureBox();
            ofdFoto = new OpenFileDialog();
            btnNew = new Button();
            btnSave = new Button();
            bntDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)txtId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 94);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 139);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 3;
            label4.Text = "Foto";
            // 
            // txtNombre
            // 
            txtNombre.AccessibleRole = AccessibleRole.Clock;
            txtNombre.Location = new Point(98, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(98, 91);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 5;
            // 
            // txtId
            // 
            txtId.Location = new Point(98, 21);
            txtId.Name = "txtId";
            txtId.Size = new Size(120, 23);
            txtId.TabIndex = 6;
            // 
            // lnkfoto
            // 
            lnkfoto.AutoSize = true;
            lnkfoto.Location = new Point(12, 172);
            lnkfoto.Name = "lnkfoto";
            lnkfoto.Size = new Size(67, 15);
            lnkfoto.TabIndex = 7;
            lnkfoto.TabStop = true;
            lnkfoto.Text = "Seleccionar";
            // 
            // picFoto
            // 
            picFoto.BackColor = SystemColors.ActiveCaption;
            picFoto.Location = new Point(98, 139);
            picFoto.Name = "picFoto";
            picFoto.Size = new Size(120, 103);
            picFoto.TabIndex = 8;
            picFoto.TabStop = false;
            // 
            // ofdFoto
            // 
            ofdFoto.FileName = "openFileDialog1";
            // 
            // btnNew
            // 
            btnNew.Location = new Point(12, 251);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(75, 23);
            btnNew.TabIndex = 9;
            btnNew.Text = "NEW";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(191, 251);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // bntDelete
            // 
            bntDelete.Location = new Point(98, 251);
            bntDelete.Name = "bntDelete";
            bntDelete.Size = new Size(75, 23);
            bntDelete.TabIndex = 11;
            bntDelete.Text = "DELETE";
            bntDelete.UseVisualStyleBackColor = true;
            // 
            // fr_clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 286);
            Controls.Add(bntDelete);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(picFoto);
            Controls.Add(lnkfoto);
            Controls.Add(txtId);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "fr_clientes";
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)txtId).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFoto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private NumericUpDown txtId;
        private LinkLabel lnkfoto;
        private PictureBox picFoto;
        private OpenFileDialog ofdFoto;
        private Button btnNew;
        private Button btnSave;
        private Button bntDelete;
    }
}