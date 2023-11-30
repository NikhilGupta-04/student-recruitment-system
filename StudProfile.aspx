<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudProfile.aspx.cs" Inherits="student.StudProfile" %>
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
                        <center><h4>Student profile</h4></center>
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
                              <asp:Label ID="LabelDateofbirth" runat="server" Text="Date of Birth : "></asp:Label>
                              <asp:Label ID="LabelDateofbirth1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelContactNo" runat="server" Text="Contact No : "></asp:Label>
                              <asp:Label ID="LabelContactNo1" runat="server" Text=""></asp:Label>
                          </div>                              
                          <div>
                              <asp:Label ID="LabelUniversity" runat="server" Text="University : "></asp:Label>
                              <asp:Label ID="LabelUniversity1" runat="server" Text=""></asp:Label>
                          </div>
                          <div>
                              <asp:Label ID="LabelCollegeName" runat="server" Text="College Name : "></asp:Label>
                              <asp:Label ID="LabelCollegeName1" runat="server" Text=""></asp:Label>
                          </div>
                          <br/>
                          <div>
                              <asp:Button ID="Buttonedit" runat="server" width="25%" class="btn btn-primary" Text="Edit" OnClick="Buttonedit_Click"/>
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
                           <h4>Education</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                   </div>
                   <asp:Panel ID="Paneleducation" runat="server">
                       <asp:DataList ID="DataListstudeducation" runat="server" width= "100%">
                           <ItemTemplate>
                               <div class="card">
                                   <div class="card-body">
                                       <div>
                                           <asp:Label ID="LabelEducationLevel" runat="server" Text="Education Level : "/>
                                           <%# Eval("Education_level")%>                                       
                                       </div>                 
                                       <div>
                                           <asp:Label ID="LabelFeildOfStudy" runat="server" Text="Feild Of Study : "></asp:Label>
                                           <%# Eval("Feild_of_study")%>                                       
                                       </div>                
                                       <div>
                                           <asp:Label ID="LabelPercentagege" runat="server" Text="Percentagege : "></asp:Label>
                                            <%# Eval("percentage_aggregate")%>
                                       </div>
                                       <br />
                                       <div>
                               <asp:Button ID="ButtonDelete" runat="server" Width="25%" Text="Delete" class="btn btn-primary" OnClick="ButtonDelete_Click" CommandArgument=<%# Eval("ID")%>/>
                                           <asp:Button ID="ButtonUpdate" runat="server" Width="25%" Text="Update" class="btn btn-primary" OnClick="buttonupdateeducation_Click" CommandArgument=<%# Eval("ID")%>/>
                                       </div>
                                 </div>
                                </div>
                                <br />
                           </ItemTemplate>
                       </asp:DataList>
                   </asp:Panel>
                   <br />
                   <div class="row">
                       <div class="col">
                       <asp:Button ID="Btnadd" runat="server" Text="Add" Width="50%" class="btn btn-primary" OnClick="Btnadd_Click"/>
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
                           <h4>Skills</h4>
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                   </div>
                   <div>
                       <asp:Panel ID="Panelstudskills" runat="server">
                           
                            <asp:GridView ID="GridViewSkills" runat="server" AutoGenerateColumns="False" Width="50%" OnRowCommand="GridViewSkills_RowCommand" OnRowDeleted="GridViewSkills_RowDeleted" BorderColor="White" >
                                <Columns>

                                    <asp:BoundField HeaderText="Skills" DataField="skill" />
                                    <asp:ButtonField CommandName="delete" HeaderText="Action" Text="Delete" ButtonType="image" ImageUrl="~/images/delete1.png">
                                    <ControlStyle Height="25px" Width="25px" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>  
                        </asp:Panel>
                         <br/>                       
                        <asp:Button ID="BtnSkills" runat="server" Text="Add" class="btn btn-primary" width="50%" OnClick="Button2_Click"/>
                   </div>                 
                   <br/>
       
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center><h4>Upload Resume/cv</h4></center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                    <div class="card">
                      <div class="card-body">
                   <asp:Panel ID="PanelCVPload" runat="server">
                       <div class="row">
                           <div class="col">
                               <asp:FileUpload ID="FileUpload1" runat="server"/>
                           </div>
                              <asp:Button ID="Buttoncvsave" runat="server" Text="Save" class="btn btn-primary" width="50%" OnClick="Buttoncvsave_Click"/>                
                       </div>
                       <br />
                   </asp:Panel>
                          </div>
                        </div>
                   <br />
                    <div class="card">
                      <div class="card-body">
                 <asp:Panel ID="Panel1" runat="server">
                   <asp:Label ID="Label1" runat="server" Text="Download your CV/Resume here: "></asp:Label>
                   <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Download File</asp:LinkButton>
                     <br/><br/>
                   <asp:Button ID="Button1" runat="server" Text="Delete" class="btn btn-primary" width="48%" OnClick="Button1_Click1"/>
                </asp:Panel>   
                   </div>
                    </div>

                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>Applied Job</h4>
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                   </div>
                   <asp:Panel ID="Paneltchjobdisplay" runat="server">
                       <asp:DataList ID="DataListstudjobdisplay" runat="server" width= "100%">
                           <ItemTemplate>
                               <div class="card" id="postcard">
                                   <div class="card-body">
                                       <div>
                                           <asp:Label ID="LabelCompanyName" runat="server" Text="Company Name : "></asp:Label>
                                           <%# Eval("company_name")%>                  
                                       </div>
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
                                   <br />
                                   </div>
                               </div>
                               <br />
                           </ItemTemplate>
                       </asp:DataList>
                   </asp:Panel>

               </div>
            </div>
            <br/>
         </div>
      </div>
    </div>

</asp:Content>
