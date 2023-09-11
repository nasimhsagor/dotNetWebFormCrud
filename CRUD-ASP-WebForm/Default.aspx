<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD_ASP_WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="IdRegistrationForm" runat="server">
        <h2>Insert new Employee</h2>
        <table class="table table-hover">
            <tr>
                <td>
                    <asp:HiddenField ID="hdID" runat="server"></asp:HiddenField>
                </td>
            </tr>
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="IdtxtFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="IdtxtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButtonList ID="IdRbListGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                        <asp:ListItem Value="Others">Others</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Grade</td>
                <td>
                    <asp:DropDownList ID="IdDdListGrade" runat="server">
                        <asp:ListItem Text="Select Grade" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>DOB</td>
                <td>
                    <asp:TextBox ID="IdtxtDtp" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="IdSubmitBtn" OnClick="IdSubmitBtn_Click" runat="server" Text="Submit" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div></div>
    <div></div>
    <h2>All Employees</h2>
    <div>
        <asp:GridView ID="grvStudent" DataKeyNames="ID" runat="server" AutoGenerateColumns="false" OnRowCommand="grvStudent_RowCommand">
            <Columns>
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Grade" HeaderText="Grade" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" CausesValidation="false" CommandName="EditStudent" Text="Edit" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnDelete" CausesValidation="false" CommandName="DeleteStudent" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
