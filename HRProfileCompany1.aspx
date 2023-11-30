<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HRProfileCompany1.aspx.cs" Inherits="student.HRProfileCompany1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
    <div class="row">
        <div class="col-md-6 mx-auto"">
            <div class="card">
                <div class="card-body">

                     <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>About Comapny</h4>
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                   </div>

                   <div class="row">                     
                     <div class="col-md-6">
                        <label>Comany Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxCurComanyName" runat="server" placeholder=" Current Comapany Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>CMMI Level</label><br>
                        <asp:DropDownList ID="DropDownListCmmilevel" runat="server" CssClass="ddlist" Width="100%" Height="37"   placeholder="CMMI level">
                             <asp:ListItem>1</asp:ListItem>
                             <asp:ListItem>2</asp:ListItem>
                             <asp:ListItem>3</asp:ListItem>
                             <asp:ListItem>4</asp:ListItem>
                             <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                     </div>
                   </div>

                    <div class="row">                     
                     <div class="col-md-6">
                        <label>Comany Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxbio" runat="server"  placeholder="Write Something about your company" TextMode="MultiLine"></asp:TextBox>
                        </div>
                     </div>
                   </div>          
                         <asp:Button ID="BtnUpdate" runat="server" Text="Update" class="btn btn-primary"  Height="37" Width="49%" OnClick="BtnUpdate_Click"/>     
                        <asp:Button ID="Buttonreset" runat="server" Text="Reset" class="btn btn-primary" Height="37" Width="50%"/>                        
                </div>
            </div>
            <br />
         </div>
      </div>
    </div>


</asp:Content>
