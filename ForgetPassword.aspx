<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="student.ForgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
    <div class="row">
        <div class="col-md-4 mx-auto">
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
                           <h4>Reset Your Password</h4>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter the your email" ControlToValidate="TextBoxEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxPassword" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                         <label>Confirm Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToCompare="TextBoxPassword" ControlToValidate="TextBox1" ForeColor="Red" ></asp:CompareValidator>
                        </div>
                        <div class="form-group">
                            <br />
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="ButtonLogin"  OnClick="ButtonLogin_Click" runat="server" Text="Set New Password" />
                        </div>                                                
                     </div>
                  </div>
                   
                </div>
            </div>
            <br />
        </div>
    </div>
</div>
</asp:Content>
