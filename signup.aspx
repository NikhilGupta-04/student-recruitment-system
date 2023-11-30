<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="student.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">                       
                           <img width="100" class="rounded mx-auto d-block" src="images/generaluser.png"/>                       
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Sign Up</h4>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName" ErrorMessage="Please enter name*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="TextBoxDob" runat="server"  TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatordob" runat="server" ControlToValidate="TextBoxDob" ErrorMessage="Please enter DOB*" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                    <div class="col-md-6">
                        <label>Phone Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxPhoneNo" runat="server" placeholder="Contact No"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPhoneNo" ErrorMessage="Invalid Number*" ValidationExpression="^[7-9][0-9]{9}$" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                    </div>                     
                    <div class="col-md-6">
                       <label>Email ID</label>
                       <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxEmail" runat="server" placeholder="Email ID" TextMode="Email" ></asp:TextBox>
                           
                           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Invalid Email*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                           <asp:Label ID="Labelemail" runat="server" Text="Label"></asp:Label>
                       </div>
                     </div>
                  </div>  

                  <div class="row">
                     <div class="col-md-6">
                         <label>Profession</label>
                         <div class="form-group">
                             <asp:DropDownList ID="DropDownListprofession" runat="server" CssClass="form-control" Height="35">
                                <asp:ListItem>HR</asp:ListItem>
                                <asp:ListItem>Teacher</asp:ListItem>
                                <asp:ListItem>Student</asp:ListItem>
                                </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorProf" runat="server" ControlToValidate="DropDownListprofession" ErrorMessage="At least Select One*" ForeColor="Red"></asp:RequiredFieldValidator>
                         </div>
                     </div>
                     <div class="col-md-6">
                         <label>Gender </label>
                         <asp:DropDownList ID="DropDownListGender" runat="server" CssClass="form-control" Height="35">
                             <asp:ListItem>Male</asp:ListItem>
                             <asp:ListItem>Female</asp:ListItem>
                             <asp:ListItem>Others</asp:ListItem>
                             </asp:DropDownList>                            
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DropDownListGender" ErrorMessage="At least select one*" ForeColor="Red"></asp:RequiredFieldValidator>
                     </div>
                  </div>

                  <div class="row">
                      <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxPassword" runat="server" placeholder="Password"  TextMode="Password" ValidationGroup="custom"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-6">
                        <label>Confirm Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxComfirmPassword" runat="server" placeholder="Re-Enter Password" TextMode="Password" ValidationGroup="custom"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxComfirmPassword" ErrorMessage="Password Does't Match*" ForeColor="Red"></asp:CompareValidator>
                        </div>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col">
                          <div class="form-group">
                          <asp:Button class="btn btn-success btn-block btn-lg" ID="ButtonSignUp" runat="server" Text="SignUp" OnClick="SignUpButtonClick"/>
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
