<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Apptitude.aspx.cs" Inherits="student.Apptitude" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="css/Aptitude.css" rel="stylesheet" />
    <link href="css/Aptitude1.css" rel="stylesheet" />
<div class="container">
      <div class="row">
         <div class="col-md-12 mx-auto">
            <div class="card">
               <div class="card-body">

                   <div class="row">
                     <div class="col">
                           <hr />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Apptitude</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>


                   <div class="col-md-5">                  
                          <div>
                              <asp:Label ID="Labelname" runat="server" Text="Name : "></asp:Label>
                              <asp:Label ID="Labelname1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelGender" runat="server" Text="Date : "></asp:Label>
                              <asp:Label ID="LabelGender1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelDateofbirth" runat="server" Text="Time : "></asp:Label>
                              <asp:Label ID="LabelDateofbirth1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelContactNo" runat="server" Text="Company : "></asp:Label>
                              <asp:Label ID="LabelContactNo1" runat="server" Text=""></asp:Label>
                          </div>                              
                          <div>
                              <asp:Label ID="LabelUniversity" runat="server" Text="Job : "></asp:Label>
                              <asp:Label ID="LabelUniversity1" runat="server" Text=""></asp:Label>
                          </div>                      
                        </div>
                    
                   <div class="row">
                     <div class="col">
                           <hr />
                     </div>
                  </div>
                   <div class="examstart">
                       <p>Your exam start with in</p>
                   </div>
                   <h6>Time</h6>
                   <div class="butonexam">
                       <asp:Button ID="btnnext" runat="server" width="25%" class="btn btn-primary" Text="Next"/>
                   </div>

               </div>
            </div>
             <br />
         </div>
      </div>
</div>

</asp:Content>
