<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HRPostJob.aspx.cs" Inherits="student.HRPostJob" %>
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
                           <h4>Job Post</h4>
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
                         <label>Company Name</label>
                         <asp:TextBox CssClass="form-control" ID="TextBoxCompanyName" runat="server" placeholder="Company Name"></asp:TextBox>
                     </div>
                     <div class="col-md-6">
                        <label>Job Tittle</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxJobTittle" runat="server" 
                               placeholder="Job Tittle"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxJobTittle" ErrorMessage="Please enter job" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>                    
                 </div>

                 <div class="row">
                     <div class="col-md-6">
                        <label>Department</label><br>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxDepartment" runat="server" 
                               placeholder="Department"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDepartment" ErrorMessage="Please enter" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Skills Required</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxSkillsRequired" runat="server" 
                               placeholder="Skills Required"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxSkillsRequired" ErrorMessage="Please enter skills" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>                     
                 </div>

                 <div class="row">
                     <div class="col-md-6">
                        <label>Package</label><br>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxPackage" runat="server" 
                               placeholder="Package"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPackage" ErrorMessage="Please enter package" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Location</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxLocation" runat="server" 
                               placeholder="Location"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxLocation" ErrorMessage="Please enter location" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>                    
                     <div class="col-md-6">
                        <label>Work Type</label><br>
                        <div class="form-group">
                            <asp:DropDownList ID="DropDownListWorkType" runat="server" CssClass="form-control" Height="35">
                                <asp:ListItem Value="">Please Select</asp:ListItem>
                                <asp:ListItem>Full Time</asp:ListItem>
                                <asp:ListItem>Part Time</asp:ListItem>
                                <asp:ListItem>Internship</asp:ListItem>
                                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownListWorkType" ErrorMessage="Please select proper type" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                     </div>
                 </div>
                 
                 <div class="row">                     
                     <div class="col-md-6">
                        <label>Job Role</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxJobRole" runat="server" placeholder="Job Role in detail" 
                               TextMode="MultiLine" width="210%"></asp:TextBox>
                        </div>
                     </div>                    
                 </div>
                 <asp:Button ID="Buttonnext" runat="server" Text="Next" class="btn btn-primary" Width="50%" OnClick="Buttonnext_Click1"/>                           
                </div>
            </div>             
             <br>
        </div>
    </div>
</div>
</asp:Content>
