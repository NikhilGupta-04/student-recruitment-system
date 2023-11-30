<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudSkills.aspx.cs" Inherits="student.StudSkills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
    <div class="row">
        <div class="col-md-6 mx-auto">
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
                           <h4>Skills</h4>
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
                        <label>Skills</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxSkills" runat="server" placeholder="Eg. HTML"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Is Required." ControlToValidate="TextBoxSkills" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                      </div>
                 </div>

                 <div class="row">                     
                     <div class="col-md-6">
                         <div>
                             <br/>
                             <asp:Button ID="BtSave" runat="server" Text="Save" class="btn btn-primary" Width="100%" OnClick="BtSave_Click"/>
                         </div>                       
                     </div> 
                   </div>
                  
                </div>
            </div>             
            <br/>
        </div>
    </div>
</div>
</asp:Content>
