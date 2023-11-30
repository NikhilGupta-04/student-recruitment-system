<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tchprofile.aspx.cs" Inherits="student.Tchprofile" %>
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
                           <h4>Teacher profile</h4>
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
                          <div>
                              <asp:Label ID="Labelname" runat="server" Text="Name : "></asp:Label>
                              <asp:Label ID="Labelname1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelGender" runat="server" Text="Gender : "></asp:Label>
                              <asp:Label ID="LabelGender1" runat="server" Text=""></asp:Label>
                          </div>                          
                          <div>
                              <asp:Label ID="LabelContactNo" runat="server" Text="Contact No : "></asp:Label>
                              <asp:Label ID="LabelContactNo1" runat="server" Text=""></asp:Label>
                          </div>                              
                          <div>
                              <asp:Label ID="LabelEmail" runat="server" Text="Email ID : "></asp:Label>
                              <asp:Label ID="LabelEmail1" runat="server" Text=""></asp:Label>
                          </div>
                          <br/>
                          <div>
                              <asp:Button ID="Buttonedit" runat="server" class="btn btn-primary" Text="Edit" Width="25%" OnClick="Buttonedit_Click"/>
                          </div>
                        </div>
                    </div>
                   <br />

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>About College</h4>
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                   </div>

                   <asp:Panel ID="Panelcollegedisplay" runat="server">
                   <div class="card">
                      <div class="card-body">
                          <div>
                              <asp:Label ID="LabelCollegeName" runat="server" Text="College Name : "></asp:Label>
                              <asp:Label ID="LabelCollegeName1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelNAACRating" runat="server" Text="NAAC Rating : "></asp:Label>
                              <asp:Label ID="LabelNAACRating1" runat="server" Text=""></asp:Label>
                          </div> 
                          <div>
                              <asp:Label ID="LabelDepartment" runat="server" Text="Department : "></asp:Label>
                              <asp:Label ID="LabelDepartment1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelUniversity" runat="server" Text="University : "></asp:Label>
                              <asp:Label ID="LabelUniversity1" runat="server" Text=""></asp:Label>
                          </div>
                          <br />
                          <asp:Button ID="ButtonDelete" runat="server" Text="Delete" class="btn btn-primary" width="25%" CommandArgument=<%# Eval("collID")%> OnClick="ButtonDelete_Click"/> 
                          <asp:Button ID="Buttonupdate" runat="server" Text="Update" class="btn btn-primary" width="25%" OnClick="Buttonupdate_Click"/> 
                       </div>
                    </div>
                   </asp:Panel>               

                   <asp:Panel ID="Panelcollegebutton" runat="server">
                       <br/>
                       <asp:Button ID="Btnadd" runat="server" Text="Add" class="btn btn-primary" width="50%" OnClick="Btnadd_Click"/> 
                   </asp:Panel>
         </div>
      </div>
        <br/>
    </div>
   </div>
 </div>
</asp:Content>