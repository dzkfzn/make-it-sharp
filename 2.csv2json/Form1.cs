using System.Text.Json;

namespace _2.csv2json;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnConvert_Click(object sender, EventArgs e)
    {
        try
        {
            var objects = Util.Convert2Json(txtCSV.Text);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            txtJSON.Text = JsonSerializer.Serialize(objects, options);
            lblStatus.Text = "converted successfully";
            lblStatus.ForeColor = Color.Green;
        }
        catch (Exception)
        {
            lblStatus.Text = "invalid format csv";
            lblStatus.ForeColor = Color.Red;
        }
    }
    public static void CopyTextToClipboard(string text)
    {
        try
        {
            Clipboard.SetText(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while copying text to clipboard: " + ex.Message);
        }
    }

    private void btnCopy_Click(object sender, EventArgs e)
    {
        CopyTextToClipboard(txtJSON.Text);
    }
}
