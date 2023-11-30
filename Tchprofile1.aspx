<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tchprofile1.aspx.cs" Inherits="student.Tchprofile1" %>
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
                           <img width="100" class="rounded mx-auto d-block" src="images/generaluser.png" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Edit</h4>
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
                        <label>Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxName" runat="server" placeholder="Name"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-6">
                            <label>Gender</label>
                            <asp:DropDownList ID="DropDownListGender" runat="server" CssClass="ddlist" Width="310" placeholder="Select an option" Height="35">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>                            
                      </div>
                  </div>                   
                  <div class="row">  
                      <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxemail" runat="server" placeholder="Email ID"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxContactno" runat="server" placeholder="Contact No" TextMode="Number"/>
                        </div>
                     </div>
                  </div>
                     <br/>                       
                     <asp:Button ID="Btnupdate" runat="server" Text="Update" class="btn btn-primary"  width="50%"/>
                     <asp:Button ID="ButtonReset" runat="server" Text="Reset" class="btn btn-primary" width="49%" OnClick="ButtonReset_Click"/> 
                </div>
             </div>
          </div>
    </div>
</div>

</asp:Content>
