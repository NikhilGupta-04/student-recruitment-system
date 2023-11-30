<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudProfile2.aspx.cs" Inherits="student.StudProfile2" %>
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
                        <center><h4>Student profile</h4></center>
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
                           <asp:TextBox CssClass="form-control" ID="TextBoxName" runat="server" 
                               placeholder="Name"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-6">
                            <label>Gender</label>
                            <asp:DropDownList ID="DropDownListGender" runat="server" CssClass="ddlist" Width="100%" placeholder="Select an option" Height="35">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:DropDownList>                            
                      </div>
                  </div>
                   
                  <div class="row">                      
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxDOB" runat="server" placeholder="Date Of Birth" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxContactNo" runat="server" placeholder="Contact No"></asp:TextBox>
                        </div>
                   </div>
                   </div>

                  <div class="row">      
                      <div class="col-md-6">
                        <label>University Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxUniversityName" runat="server" 
                               placeholder="University Name"></asp:TextBox>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>College Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxCollegeName" runat="server" 
                               placeholder="College Name"></asp:TextBox>
                        </div> 
                     </div>
                  </div>
                   <asp:Button ID="Buttonupdate" runat="server" Text="Update" class="btn btn-primary" width="50%" Height="37" OnClick="Buttonupdate_Click"/>
                   <asp:Button ID="Buttonreset" runat="server" Text="Reset" class="btn btn-primary" width="49%" Height="37" OnClick="Buttonreset_Click"/>
               </div>
            </div>
            <br />
        </div>
    </div>
</div>

</asp:Content>
