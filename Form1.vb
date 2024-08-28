Imports System.IO
Imports System.Drawing
Imports System.Net
Public Class Form1
    Public pub As String
    Public xxbxc As Color
    Public xxbx As Color = Color.Black
    Public asc As Integer = 0
    Public boi As String = ""
    Public kasm As Integer = 0
    Dim di As String()
    Private notifyicon As New NotifyIcon
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub pn_DragEnter(sender As Object, e As DragEventArgs) Handles Panel1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub pn1_DragDrop(sender As Object, e As DragEventArgs) Handles Panel1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        Label14.Text = files(files.Length - 1)
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            ComboBox1.Enabled = False
            TextBox2.Enabled = True
        Else
            ComboBox1.Enabled = True
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CheckBox1.Checked = True Then
            ComboBox1.Enabled = False
            TextBox2.Enabled = True
        Else
            ComboBox1.Enabled = True
            TextBox2.Enabled = False
        End If
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            DataGridView1.Rows.Clear()
            If CheckBox1.Checked = False Then
                Label4.Text = "筛选文件查找中，中途可能会出现未响应..."
                Dim mi As String() = Directory.GetFiles(TextBox1.Text, boi, SearchOption.AllDirectories)
                For Each s As String In mi
                    Dim lw As New FileInfo(s)
                    Dim abc As String() = s.ToString.Split({"\"}, StringSplitOptions.RemoveEmptyEntries)
                    Dim ka As Double = File.ReadAllText(s.ToString).Length / 1024 / 1024
                    DataGridView1.Rows.Add(abc(abc.Length - 1), Math.Round(ka, 3).ToString + "MB", s.ToString, lw.LastWriteTime.ToShortDateString)
                    kasm = kasm + 1
                Next
                Label4.Text = "筛选文件操作成功，已经查找到" + kasm.ToString + "个文件"
                kasm = 0
                'Label4.Text = "筛选文件操作成功，已经查找到" + kasm.ToString + "个文件"
            Else
                Label4.Text = "筛选文件查找中，中途可能会出现未响应..."
                Dim mi As String() = Directory.GetFiles(TextBox1.Text, "*." + TextBox2.Text, SearchOption.AllDirectories)
                For Each s As String In mi
                    Dim lw As New FileInfo(s)
                    Dim abc As String() = s.ToString.Split({"\"}, StringSplitOptions.RemoveEmptyEntries)
                    Dim ka As Double = File.ReadAllText(s.ToString).Length / 1024 / 1024
                    DataGridView1.Rows.Add(abc(abc.Length - 1), Math.Round(ka, 3).ToString + "MB", s.ToString, lw.LastWriteTime.ToShortDateString)
                    kasm = kasm + 1
                Next
                Label4.Text = "筛选文件操作成功，已经查找到" + kasm.ToString + "个文件"
                kasm = 0
                'Label4.Text = "筛选文件操作成功，已经查找到" + kasm.ToString + "个文件"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then
            boi = "*.txt"
        ElseIf ComboBox1.SelectedIndex = 0 Then
            boi = "*.*"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            boi = "*.exe"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            boi = "*.pdf"
        ElseIf ComboBox1.SelectedIndex = 4 Then
            boi = "*.sln"
        ElseIf ComboBox1.SelectedIndex = 5 Then
            boi = "*.c"
        ElseIf ComboBox1.SelectedIndex = 6 Then
            boi = "*.cpp"
        ElseIf ComboBox1.SelectedIndex = 7 Then
            boi = "*.sb2"
        ElseIf ComboBox1.SelectedIndex = 8 Then
            boi = "*.lang"
        ElseIf ComboBox1.SelectedIndex = 9 Then
            boi = "*.ppt"
        ElseIf ComboBox1.SelectedIndex = 10 Then
            boi = "*.pptx"
        ElseIf ComboBox1.SelectedIndex = 11 Then
            boi = "*.mp4"
        ElseIf ComboBox1.SelectedIndex = 12 Then
            boi = "*.cs"
        ElseIf ComboBox1.SelectedIndex = 13 Then
            boi = "*.xml"
        ElseIf ComboBox1.SelectedIndex = 14 Then
            boi = "*.jpg"
        ElseIf ComboBox1.SelectedIndex = 15 Then
            boi = "*.e"
        ElseIf ComboBox1.SelectedIndex = 16 Then
            boi = "*.bmp"
        ElseIf ComboBox1.SelectedIndex = 17 Then
            boi = "*.gif"
        ElseIf ComboBox1.SelectedIndex = 18 Then
            boi = "*.doc"
        ElseIf ComboBox1.SelectedIndex = 19 Then
            boi = "*.aux"
        End If
        Label4.Text = "已经选中后缀名：" + boi
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Dim process As New Process()
        process.StartInfo.FileName = "cmd.exe"
        process.StartInfo.UseShellExecute = False
        process.StartInfo.RedirectStandardInput = True
        process.StartInfo.RedirectStandardOutput = True
        process.StartInfo.RedirectStandardError = True
        process.StartInfo.CreateNoWindow = True
        process.Start()

        ' 写入命令
        process.StandardInput.WriteLine("ipconfig")
        process.StandardInput.WriteLine("exit")

        ' 获取命令的输出
        Dim output As String = process.StandardOutput.ReadToEnd()

        ' 打印输出结果
        'TextBox3.Text = output

        process.WaitForExit()
        process.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Shell("cmd.exe")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Process.Start("regeidt.exe")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Shell("taskkill /f /im explorer.exe")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Shell("explorer.exe")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        drwm()
        Shell("explorer.exe " + Directory.GetCurrentDirectory().ToString)
    End Sub
    Public Sub drwm()
        Dim bmp As New Bitmap(PictureBox1.Width, PictureBox1.Height)
        asc = 70
        Dim e As Graphics = Graphics.FromImage(bmp)
        e.Clear(Color.Red)
        Dim apc As New SolidBrush(Color.Yellow)
        e.FillRectangle(apc, 10, 10, 100, 30)
        apc.Dispose()
        Dim ft As New Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold)
        Dim cas As New SolidBrush(Color.Black)
        e.DrawString(TextBox4.Text, ft, cas, New PointF(10, 15))
        cas.Dispose()
        Dim ft1 As New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
        Dim cas1 As New SolidBrush(Color.White)
        e.DrawString("菜名                           价格", ft1, cas1, New PointF(10, 50))
        cas1.Dispose()
        Try
            Dim ft0 As New Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold)
            Dim cas0 As New SolidBrush(Color.White)
            Dim asd() As String = TextBox5.Text.Split({",", vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            For s = 0 To asd.Length Step 2
                If s = asd.Length Then
                    Exit For
                End If
                If s = 0 Then
                    e.DrawString(asd(s + 1), ft0, cas0, New PointF(150, asc))
                Else
                    e.DrawString(asd(s + 1), ft0, cas0, New PointF(150, asc))
                End If

                asc = asc + 20
                'e.DrawString(asd(2), ft0, cas0, New PointF(150, 90))
            Next
            cas0.Dispose()
            asc = 70
            Dim ft0a As New Font(FontFamily.GenericSansSerif, 13, FontStyle.Bold)
            Dim cas0a As New SolidBrush(Color.White)
            'Dim asd() As String = TextBox2.Text.Split({",", vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
            For sb = 0 To asd.Length Step 2
                If sb = asd.Length - 1 Then
                    Exit For
                End If
                'MsgBox(s)
                If sb = 0 Then
                    e.DrawString(asd(sb), ft0a, cas0a, New PointF(15, asc))
                Else
                    e.DrawString(asd(sb), ft0a, cas0a, New PointF(15, asc))
                End If
                asc = asc + 20
                'e.DrawString(asd(2), ft0, cas0, New PointF(150, 90))
            Next
        Catch ex As Exception
            PictureBox1.Image = bmp
            PictureBox1.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
            bmp.Save(Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + " " + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString + ".png", System.Drawing.Imaging.ImageFormat.Png)
            Label10.Text = "导出已经操作完成，导出至:" + Now.Year.ToString + "-" + Now.Month.ToString + "-" + Now.Day.ToString + " " + Now.Hour.ToString + "-" + Now.Minute.ToString + "-" + Now.Second.ToString + ".png。"
        End Try
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        Dim img As Image = Image.FromFile(Label14.Text)
        Dim bmp As New Bitmap(32, 32)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(img, New Rectangle(0, 0, 32, 32))
        Dim icopth As String = Path.Combine(Path.GetDirectoryName(Label14.Text), Path.GetFileNameWithoutExtension(Label14.Text) & ".ico")
        bmp.Save(icopth, Imaging.ImageFormat.Icon)
        Label14.Text = "转换完成，保存到了目录" + icopth
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Opacity = TrackBar1.Value / 100
        Label18.Text = "不透明度：" + TrackBar1.Value.ToString + "%"
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        If CheckBox2.Checked = True Then
            Me.Hide()
            notifyicon = New NotifyIcon()
            notifyicon.Icon = Me.Icon
            notifyicon.Visible = True
            notifyicon.Text = "右键->打开工具箱以打开Hpgm工具箱。"
            notifyicon.ContextMenu = New ContextMenu(New MenuItem() {New MenuItem("打开工具箱", New EventHandler(AddressOf sav))})
            notifyicon.BalloonTipTitle = "Hpgm工具箱已经最小化到任务栏区域"
            notifyicon.BalloonTipText = "点击鼠标右键->打开工具箱可以打开工具箱。"
            notifyicon.ShowBalloonTip(5000)
        Else
            Me.Show()
        End If
    End Sub
    Private Sub sav(sender As Object, e As EventArgs)
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        notifyicon.Visible = False
        CheckBox2.Checked = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Process.Start("https://jx.xmflv.com/?url=" + TextBox6.Text)
        'http://music.163.com/song/media/outer/url?id=1857630559.mp3
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            di = TextBox7.Text.Split({"?", "="}, StringSplitOptions.RemoveEmptyEntries)
            Label23.Text = "解析完成，音乐ID为" + di(di.Length - 1) + "!"
            LinkLabel1.Visible = True
        Catch ex As Exception
            Me.Hide()
            Form2.Show()
            Form2.TextBox1.Text = ex.ToString
        End Try
        'Process.Start("http://music.163.com/song/media/outer/url?id=" + di(di.Length - 1) + ".mp3")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Using dnf As New WebClient()
                dnf.DownloadFile("http://music.163.com/song/media/outer/url?id=" + di(di.Length - 1) + ".mp3", "Music_Id_" + di(di.Length - 1) + ".mp3")
                MsgBox("下载操作完成，保存在Music_Id_" + di(di.Length - 1) + ".mp3", vbYes, "操作完成")
            End Using
        Catch ex As Exception
            Me.Hide()
            Form2.Show()
            Form2.TextBox1.Text = ex.ToString
        End Try
        'Process.Start("http://music.163.com/song/media/outer/url?id=" + di(di.Length - 1) + ".mp3")
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            xxbxc = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        TEXT_CONVERT_TO_STRING_22BXC174E6PAH145_AA1CB()
    End Sub
    Public Sub TEXT_CONVERT_TO_STRING_22BXC174E6PAH145_AA1CB()
        Try
            Dim fontsize As Integer = TextBox3.Text
            Dim a59999 As New Bitmap(PictureBox2.Width, PictureBox2.Height)
            Dim e As Graphics = Graphics.FromImage(a59999)
            e.Clear(xxbxc)
            Dim font As New Font("SimSun", fontsize, FontStyle.Regular)
            Dim brush As New SolidBrush(xxbx)
            Dim foma As New StringFormat()
            foma.FormatFlags = StringFormatFlags.LineLimit Or StringFormatFlags.NoClip
            Dim rect As New RectangleF(1.0F, 1.0F, 368.0F, 397.0F)
            e.DrawString(RichTextBox1.Text, font, brush, rect, foma)
            brush.Dispose()
            PictureBox2.Image = a59999
            PictureBox2.DrawToBitmap(a59999, New Rectangle(0, 0, a59999.Width, a59999.Height))
            a59999.Save("Output.png", System.Drawing.Imaging.ImageFormat.Png)
            MsgBox("转换完成,保存到了Output.png", vbYes, "文字转换图片")
        Catch ex As Exception
            Me.Hide()
            Form2.Show()
            Form2.TextBox1.Text = ex.ToString
        End Try

    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        If ColorDialog2.ShowDialog() = DialogResult.OK Then
            xxbx = ColorDialog2.Color
        End If
    End Sub
End Class
