namespace LoginLab;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitle = null!;
    private Label lblLoginSection = null!;
    private Label lblLoginUsername = null!;
    private TextBox txtLoginUsername = null!;
    private Label lblLoginPassword = null!;
    private TextBox txtLoginPassword = null!;
    private Button btnLogin = null!;
    private Label lblCreateSection = null!;
    private Label lblNewUsername = null!;
    private TextBox txtNewUsername = null!;
    private Label lblNewPassword = null!;
    private TextBox txtNewPassword = null!;
    private Label lblConfirmPassword = null!;
    private TextBox txtConfirmPassword = null!;
    private Button btnCreateUser = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblLoginSection = new Label();
        lblLoginUsername = new Label();
        txtLoginUsername = new TextBox();
        lblLoginPassword = new Label();
        txtLoginPassword = new TextBox();
        btnLogin = new Button();
        lblCreateSection = new Label();
        lblNewUsername = new Label();
        txtNewUsername = new TextBox();
        lblNewPassword = new Label();
        txtNewPassword = new TextBox();
        lblConfirmPassword = new Label();
        txtConfirmPassword = new TextBox();
        btnCreateUser = new Button();
        SuspendLayout();
        // Form title
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitle.Location = new Point(190, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(230, 37);
        lblTitle.Text = "User Login Lab";
        // Existing user section
        lblLoginSection.AutoSize = true;
        lblLoginSection.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblLoginSection.Location = new Point(45, 85);
        lblLoginSection.Name = "lblLoginSection";
        lblLoginSection.Text = "Existing User Login";
        lblLoginUsername.AutoSize = true;
        lblLoginUsername.Location = new Point(48, 130);
        lblLoginUsername.Name = "lblLoginUsername";
        lblLoginUsername.Text = "Username";
        txtLoginUsername.Location = new Point(190, 126);
        txtLoginUsername.Name = "txtLoginUsername";
        txtLoginUsername.Size = new Size(340, 27);
        txtLoginUsername.TabIndex = 0;
        lblLoginPassword.AutoSize = true;
        lblLoginPassword.Location = new Point(48, 172);
        lblLoginPassword.Name = "lblLoginPassword";
        lblLoginPassword.Text = "Password";
        txtLoginPassword.Location = new Point(190, 168);
        txtLoginPassword.Name = "txtLoginPassword";
        txtLoginPassword.Size = new Size(340, 27);
        txtLoginPassword.TabIndex = 1;
        btnLogin.Location = new Point(190, 210);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(150, 36);
        btnLogin.TabIndex = 2;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // Create user section
        lblCreateSection.AutoSize = true;
        lblCreateSection.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblCreateSection.Location = new Point(45, 285);
        lblCreateSection.Name = "lblCreateSection";
        lblCreateSection.Text = "Create a New User";
        lblNewUsername.AutoSize = true;
        lblNewUsername.Location = new Point(48, 332);
        lblNewUsername.Name = "lblNewUsername";
        lblNewUsername.Text = "Username";
        txtNewUsername.Location = new Point(190, 328);
        txtNewUsername.Name = "txtNewUsername";
        txtNewUsername.Size = new Size(340, 27);
        txtNewUsername.TabIndex = 3;
        lblNewPassword.AutoSize = true;
        lblNewPassword.Location = new Point(48, 374);
        lblNewPassword.Name = "lblNewPassword";
        lblNewPassword.Text = "Password";
        txtNewPassword.Location = new Point(190, 370);
        txtNewPassword.Name = "txtNewPassword";
        txtNewPassword.Size = new Size(340, 27);
        txtNewPassword.TabIndex = 4;
        lblConfirmPassword.AutoSize = true;
        lblConfirmPassword.Location = new Point(48, 416);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Text = "Confirm Password";
        txtConfirmPassword.Location = new Point(190, 412);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.Size = new Size(340, 27);
        txtConfirmPassword.TabIndex = 5;
        btnCreateUser.Location = new Point(190, 455);
        btnCreateUser.Name = "btnCreateUser";
        btnCreateUser.Size = new Size(150, 36);
        btnCreateUser.TabIndex = 6;
        btnCreateUser.Text = "Create User";
        btnCreateUser.UseVisualStyleBackColor = true;
        btnCreateUser.Click += btnCreateUser_Click;
        // Form
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(590, 530);
        Controls.Add(lblTitle);
        Controls.Add(lblLoginSection);
        Controls.Add(lblLoginUsername);
        Controls.Add(txtLoginUsername);
        Controls.Add(lblLoginPassword);
        Controls.Add(txtLoginPassword);
        Controls.Add(btnLogin);
        Controls.Add(lblCreateSection);
        Controls.Add(lblNewUsername);
        Controls.Add(txtNewUsername);
        Controls.Add(lblNewPassword);
        Controls.Add(txtNewPassword);
        Controls.Add(lblConfirmPassword);
        Controls.Add(txtConfirmPassword);
        Controls.Add(btnCreateUser);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "User Login";
        ResumeLayout(false);
        PerformLayout();
    }
}
