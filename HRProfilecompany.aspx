<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HRProfilecompany.aspx.cs" Inherits="student.HRProfilecompany" %>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCurComanyName" ErrorMessage="Please enter your company" ForeColor="Red"></asp:RequiredFieldValidator>
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
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownListCmmilevel" ErrorMessage="Please select proper type" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>
                   </div>

                    <div class="row">                     
                     <div class="col-md-6">
                        <label>Bio</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxbio" runat="server"  placeholder="Write Something about your company" TextMode="MultiLine"></asp:TextBox>
                        </div>
                     </div>
                   </div>
                    <br/>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" class="btn btn-primary" width="50%" Height="37" OnClick="BtnUpdate_Click1"/>
                    <asp:Button ID="Buttonreset" runat="server" Text="reset" class="btn btn-primary" width="49%" Height="37"/>                       
                </div>
            </div>
            <br />
         </div>
      </div>
    </div>
</asp:Content>
