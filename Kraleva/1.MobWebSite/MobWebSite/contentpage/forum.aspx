<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="MobWebSite.contentpage.forum" %>


<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=240, height=320, user-scalable=yes, initial-scale=1.0, maximum-scale=5.0, minimum-scale=1.0" />
    <meta name="author" content="Atanas Kambitov" />
    <meta name="keyword" content="Mobile website example, HTML 5, CSS 3, JavaScript" />

    <title>MobWebSite</title>

    <link rel="icon" href="../favicon/favicon.ico" />
    <link href="../index-files/mobStyle.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <header>Mobile website</header>
     <div id="main">
         <h1>FORUM</h1>
         <div id="borderText">
             <div class="nav">
                 <ul>
                     <li><a href="gallery.html">Prev</a></li>
                     <li><a href="../index.html">Home</a></li>
                     <li><a href="author.html">Next</a></li>
                 </ul>
             </div>
             <form id="form1" runat="server">
                <div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myMobWSConnectionString %>" ProviderName="<%$ ConnectionStrings:myMobWSConnectionString.ProviderName %>" SelectCommand="SELECT [Visitor], [Date], [Description] FROM [tblVisitor]"></asp:SqlDataSource>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" Text="Name"></asp:Label>
                    <asp:TextBox ID="tbName" runat="server" Width="210px">Author</asp:TextBox>
                </div>
                </form>
         </div> 
     </div>
     <footer>
        <a href="http://timetable.swu.bg/lecture/rkraleva/ZimenSem/MobApp/mobApp.html">Full site</a><br />
        &copy; 2017 Atanas Kambitov &alefsym;<br />
        ALL RIGHT RESERVED<br />
    </footer>
</body>
</html>
