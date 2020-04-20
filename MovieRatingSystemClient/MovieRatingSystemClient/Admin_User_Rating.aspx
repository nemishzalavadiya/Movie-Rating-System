<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_User_Rating.aspx.cs" Inherits="MovieRatingSystemClient.Admin_User_Rating" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;margin:15px;">
            <span style="margin-right:10px"> 
            <asp:Button ID="Movie__" runat="server" 
                Text="Movie" Width="198px" OnClick="Movie___Click"  /></span> 
           <span style="margin-right:10px">  
            <asp:Button ID="User__" runat="server" 
                Text="User" Width="204px" OnClick="User___Click" /></span> 
           <span style="margin-right:10px">  
            <asp:Button ID="Movie_Rating__" runat="server" 
                Text="Movie Ratings" Width="234px" OnClick="Movie_Rating___Click" /></span> 
            <span style="margin-right:10px">  
            <asp:Button ID="Logout" runat="server" 
                Text="Logout"  Width="234px" OnClick="Logout_Click" /></span> 
        </div>
        <div style="text-align:center">
            <asp:Label runat="server" ID="Admin_User_Rating_Label"></asp:Label>
        </div>
        <div style="text-align:center;margin-top:40px;align-items:center">

            <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" 
                GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
