<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="student.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/login.css" rel="stylesheet" />
<div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                           <img width="150" class="rounded mx-auto d-block" src="images/generaluser.png"/>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>User Login</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxEmail" runat="server" placeholder="Email ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Please enter your email" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="Please enter your password" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                         <div class="forgetbuttonon">
                             <a href="ForgetPassword.aspx">Forget Password?</a>
                         </div>
                        <div class="form-group">
                            <br />
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
                        </div>
                        <div class="form-group">
                           <a href="signup.aspx"><input class="btn btn-info btn-block btn-lg" id="ButtonSignUp" type="button" value="Sign Up" /></a>
                        </div>
                         <div class="forgetbuttonon">
                             <a href="signup.aspx">Not Register Yet!</a>
                         </div>
                     </div>
                  </div>
               </div>
            </div>
             <br>
         </div>
      </div>
</div>
</asp:Content>
