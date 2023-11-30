<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TchCollege1.aspx.cs" Inherits="student.TchCollege1" %>
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
                           <h4>Teacher College Update</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>    

                  <div class="card">
                      <div class="card-body">
                          <div class="row">
                              <div class="col-md-6">
                                  <label>College Name</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBoxCurCollegeName" runat="server" placeholder="Current Comapany Name"/>
                                  </div>
                              </div>
                              <div class="col-md-6">
                                  <label>NAAC Rating</label><br>
                                  <asp:DropDownList ID="DropDownListNAACRating" runat="server" CssClass="ddlist" Width="100%" Height="35" placeholder="CMMI level">
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
                                  <label>Department</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBoxDepartment" runat="server" placeholder="Department"></asp:TextBox>
                                  </div>
                               </div>     
                               <div class="col-md-6">
                                   <label>University Name</label>
                                   <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBoxUniversityName" runat="server" placeholder="University Name" />
                                   </div>
                                </div>
                          </div>

                          <br />
                          <asp:Button ID="Btnupdate" runat="server" Text="Update" class="btn btn-primary" width="50%" OnClick="Btnupdate_Click1"/>
                          <asp:Button ID="Buttoncancel" runat="server" Text="Cancel" class="btn btn-primary" width="49%" OnClick="Buttoncancel_Click"/>
                      </div>
                   </div>

               </div>
            </div>
             <br />
         </div>
      </div>
</div>

</asp:Content>
