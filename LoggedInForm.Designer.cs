namespace LoginLab;

partial class LoggedInForm
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblWelcome = null!;
    private Button btnLogout = null!;
    private Button btnExit = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblWelcome = new Label();
        btnLogout = new Button();
        btnExit = new Button();
        SuspendLayout();
        lblWelcome.AutoSize = false;
        lblWelcome.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblWelcome.Location = new Point(25, 55);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(510, 80);
        lblWelcome.Text = "You have successfully logged in!";
        lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
        btnLogout.Location = new Point(135, 165);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(130, 40);
        btnLogout.Text = "Logout";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        btnExit.Location = new Point(295, 165);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(130, 40);
        btnExit.Text = "Exit";
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += btnExit_Click;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(560, 270);
        Controls.Add(lblWelcome);
        Controls.Add(btnLogout);
        Controls.Add(btnExit);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "LoggedInForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Logged In";
        ResumeLayout(false);
    }
}
