<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="MovieRatingSystemClient.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center;margin:15px;">
           <span style="margin-right:10px"> 
            <asp:Button ID="Movie" runat="server" 
                Text="Movie" OnClick="Movie_Click" Width="198px" /></span> 
           <span style="margin-right:10px">  
            <asp:Button ID="User" runat="server" 
                Text="User" OnClick="User_Click" Width="204px" /></span> 
           <span style="margin-right:10px">  
            <asp:Button ID="Movie_Rating" runat="server" 
                Text="Movie Ratings" OnClick="Movie_Rating_Click" Width="234px" /></span> 
            <span style="margin-right:10px">  
            <asp:Button ID="Logout" runat="server" 
                Text="Logout"  Width="234px" OnClick="Logout_Click" /></span> 
        </div>
        <div style="text-align:center">
            <asp:Label runat="server" ID="Admin_Label"></asp:Label>
        </div>
        <div style="margin-top:20px;margin-bottom:20px;">
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:TextBox placeholder="Movie Name" ID="TextBox2" runat="server" 
                            Width="270px" Height="30px" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox placeholder="Movie Type" ID="TextBox1" runat="server" 
                            Width="270px" Height="30px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox placeholder="Movie Rating" ID="TextBox3" runat="server" Width="270px" Height="30px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Add" Width="270px" Height="30px" 
                            OnClick="Button1_Click"/>
                    </td>
                </tr>
            </table>
        </div>
        <div style="text-align:center;margin-top:40px;align-items:center">

            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="100%" 
                OnRowDeleting="GridView1_RowDeleting"
                OnRowUpdating="GridView1_RowUpdating"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                
                >
                
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:ButtonField ControlStyle-BackColor="Maroon" ControlStyle-ForeColor="White" 
                        ButtonType="Button" CommandName="Delete" Text="Delete" >
<ControlStyle BackColor="Maroon" ForeColor="White"></ControlStyle>
                    </asp:ButtonField>
                    <asp:ButtonField ControlStyle-BackColor="Blue" ControlStyle-ForeColor="White" ButtonType="Button" CommandName="Update" Text="Update" />
                </Columns> 
            </asp:GridView>

        </div>
        
    </form>
</body>
</html>
