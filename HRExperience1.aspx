<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HRExperience1.aspx.cs" Inherits="student.HRExperiences" %>
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
                           <h4>Work Experiences Update</h4>
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
                           <asp:TextBox CssClass="form-control" ID="TextBoxCompanyName" runat="server" placeholder="Name"/>
                        </div>
                     </div>                    
                       <div class="col-md-6">
                           <label>Position</label><br>
                           <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBoxPosition" runat="server" placeholder="Name"/>
                           </div>
                        </div>
                   </div>

                   <div class="row">                     
                     <div class="col-md-6">
                        <label>From</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxFrom" runat="server" placeholder="From Year" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>

                     <div class="col-md-6">
                        <label>To</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxTo" runat="server" placeholder="To Year" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                   </div>

                   <div class="row">                     
                     <div class="col-md-6">
                        <label>Job Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBoxJobDescription" runat="server" 
                               placeholder="Job Description" TextMode="MultiLine" width="210%"></asp:TextBox>
                        </div>
                     </div>                    
                   </div>                  
                   <br/>
                   <asp:Button ID="BtnUpdate" runat="server" Text="Update" class="btn btn-primary" Width="50%" OnClick="BtnUpdate_Click"/>
                   <asp:Button ID="BtnReset" runat="server" Text="Cancel" class="btn btn-primary" Width="49%"/>                                
               </div>
              </div> 
              <br />
          </div>
      </div>
</div>
</asp:Content>
