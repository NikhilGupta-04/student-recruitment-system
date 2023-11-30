<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HRProfile.aspx.cs" Inherits="student.HRProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card" id="maincard">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                           <img width="100" class="rounded mx-auto d-block" src="images/generaluser.png" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>HR Profile</h4>
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
                              <asp:Label ID="LabelDob" runat="server" Text="Date of Birth : "></asp:Label>
                              <asp:Label ID="LabelDob1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelContactNo" runat="server" Text="Contact No : "></asp:Label>
                              <asp:Label ID="LabelContactNo1" runat="server" Text=""></asp:Label>
                          </div>                              
                          <div>
                              <asp:Label ID="LabelEmail" runat="server" Text="Email ID : "></asp:Label>
                              <asp:Label ID="LabelEmail1" runat="server" Text=""></asp:Label>
                          </div>                 
                           <div>
                              <asp:Label ID="LabelGender" runat="server" Text="Gender : "></asp:Label>
                              <asp:Label ID="LabelGender2" runat="server" Text=""></asp:Label>
                          </div>
                          <br />
                          <div>
                              <asp:Button ID="Buttonedit" runat="server" class="btn btn-primary" Text="Edit" OnClick="Buttonedit_Click" Width="50%"/>
                          </div>
                        </div>
                    </div> 
                   
                   <br/>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>About Comapny</h4> 
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                   </div>

                   <asp:Panel ID="Panelcompany" runat="server">
                      <div class="card">
                      <div class="card-body">
                          <div>
                              <asp:Label ID="Label1CompanyName" runat="server" Text="Company Name : "></asp:Label>
                              <asp:Label ID="Label1CompanyName1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelCMMIlevel" runat="server" Text="CMMI level : "></asp:Label>
                              <asp:Label ID="LabelCMMIlevel1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelBio" runat="server" Text="Bio : "></asp:Label>
                              <asp:Label ID="LabelBio1" runat="server" Text=""></asp:Label>
                          </div>
                          <br />
                          <div>
                            <asp:Button ID="Buttondetelet" runat="server" class="btn btn-primary" Width="25%" Text="Delete" OnClick="Buttondetelet_Click" CommandArgument=<%# Eval("compID")%>/>
                             
                              <asp:Button ID="Buttoncomapnyupdate" runat="server" class="btn btn-primary" Width="25%" Text="Update" OnClick="Buttoncomapnyupdate_Click"/>
                        </div>
                      </div>
                   </div>
                    </asp:Panel>
                   
                   <asp:Panel ID="Panelcomapntbutton" runat="server">
                     <div>
                         <br />
                            <asp:Button ID="Buttoncompanyadd" runat="server" class="btn btn-primary" Width="50%" Text="Add" OnClick="Buttoncompanyadd_Click1" />
                        </div>
                       </asp:Panel>
                   <br/>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>Work Experiences</h4>
                        </center>
                     </div>
                  </div>
                   <asp:Panel ID="PanelWorkExperiences" runat="server">
                       <asp:DataList ID="DataListWorkExperiences" runat="server" width= "100%">
                           <ItemTemplate>
                               <div class="card">
                                   <div class="card-body">
                                       <div>
                                            <asp:Label ID="LabelCompanyName" runat="server" Text="Company Name: "/>
                                            <%# Eval("Company_Name")%>
                                            <%--<asp:Label ID="LabelCompanyName2" runat="server" Text=""></asp:Label>--%>
                                       </div>
                                       <div>
                                            <asp:Label ID="LabelPosition" runat="server" Text="Position: "></asp:Label>
                                            <%# Eval("Position")%> 
                                            <%--<asp:Label ID="LabelPosition2" runat="server" Text=""></asp:Label>--%>
                                       </div>
                                       <div>
                                            <asp:Label ID="LabelFrom" runat="server" Text="From: " ></asp:Label>
                                            <%# Eval("From_Year","{0:dd/MM/yyyy}")%>
                                            <%--<asp:Label ID="LabelFrom2" runat="server" Text=""></asp:Label>--%>
                                       </div>                 
                                       <div>
                                            <asp:Label ID="LabelTo" runat="server" Text="To: "></asp:Label>
                                            <%# Eval("To_Year","{0:dd/MM/yyyy}")%>
                                            <%--<asp:Label ID="LabelTo2" runat="server" Text=""></asp:Label>--%>
                                       </div>                
                                       <div>
                                            <asp:Label ID="LabelJobDescription" runat="server" Text="Job Description: "/>
                                            <%# Eval("Job_Description")%>
                                       </div>                          
                                       <br/>
                                        <div>
                                            <asp:Button ID="delete" runat="server" class="btn btn-primary" Width="25%"
                                                OnClick="delete_Click" CommandArgument=<%# Eval("Exp_ID")%> Text="Delete" />
                                            <asp:Button ID="Buttonexperiencesupdate" runat="server" class="btn btn-primary"  Width="25%"
                                                 Text="Update" OnClick="Buttonexperiencesupdate_Click" CommandArgument=<%# Eval("Exp_ID")%> />
                                        </div>
                                    </div>
                               </div>
                           </ItemTemplate>
                       </asp:DataList>
                    </asp:Panel>
                        <div>
                            <br/>                       
                            <asp:Button ID="BtnEdit" runat="server" Text="Add" Width="50%" class="btn btn-primary" OnClick="BtnEdit_Click"/>                       
                        </div>
                   <br/>

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Post</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>               
                   <asp:Panel ID="Panel1" runat="server">
                       <asp:DataList ID="DataListjobpost" runat="server" width= "100%">
                           <ItemTemplate>
                               <div class="card" id="postcard">
                                   <div class="card-body">
                                       <div>
                                           <asp:Label ID="lblJobTittle" runat="server" Text="Job Tittle : "></asp:Label>
                                           <%# Eval("Job_Title")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblDepartment" runat="server" Text="Department : "></asp:Label>
                                           <%# Eval("Department")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblSkillsRequired" runat="server" Text="Skills Required : "></asp:Label>
                                           <%# Eval("Skills_Required")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblPackage" runat="server" Text="Package : "></asp:Label>
                                           <%# Eval("Package")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblLocation" runat="server" Text="Location : "></asp:Label>
                                           <%# Eval("Location")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="lblJobDescription" runat="server" Text="Job Description : "></asp:Label>
                                           <%# Eval("Job_Description")%>
                                       </div>
                                       <div class="row"><div class="col"><hr></div></div>
                                       <div>
                                           <asp:Label ID="Label1" runat="server" Text="Education : "></asp:Label>
                                           <%# Eval("education")%>
                                       </div>
                                       <div>
                                           <asp:Label ID="Label2" runat="server" Text="Level : "></asp:Label>
                                           <%# Eval("Level_Edu").ToString() == "1" ? "Above" : "Below" %>
                                       </div>
                                       <div>
                                           <asp:Label ID="Label3" runat="server" Text="Percentage : "></asp:Label>
                                           <%# Eval("percantage_aggregate")%>
                                       </div>
                                   <br />
                                        <asp:Button ID="Buttondeletequalification" runat="server" Text="Delete"  Width="25%"  class="btn btn-primary" CommandArgument=<%#Eval("Job_ID") %> OnClick="Buttondeletequalification_Click"/>

                                       <asp:Button ID="ButtonApplication" runat="server" Text="Application" Width="25%"  class="btn btn-primary"
                                           onclick="ButtonApplication_Click" CommandArgument=<%#Eval("Job_ID")%> />
                                   </div>
                               </div> 
                                   <br />
                           </ItemTemplate>
                       </asp:DataList>
                          <br/>
                   </asp:Panel>
               </div>
                </div>
                <br>
         </div>
       </div>
   </div>
</asp:Content>
