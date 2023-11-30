<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="student.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- main images slider container -->
        <div class="slide-window">
            <div class="slide-wrapper" style="width:300%;">
                <div class="slide">
                    <div class="slide-caption text-center">
                       <h3 class="text-uppercase">Jobs to easily <span>Get Hired.</span></h3>
                    </div>
                </div>
                <div class="slide slide2">
                    <div class="slide-caption text-center">
                        <h3 class="text-uppercase">Individual approach to <span>Each Student.</span></h3>
                    </div>
                </div>
                <div class="slide slide3">
                    <div class="slide-caption text-center">
                        <h3 class="text-uppercase">Where Talent Meets <span>Opportunity.</span></h3>
                    </div>
                </div>
            </div>
            <div class="slide-controller">
                <div class="slide-control-left">
                    <div class="slide-control-line"></div>
                    <div class="slide-control-line"></div>
                </div>
                <div class="slide-control-right">
                    <div class="slide-control-line"></div>
                    <div class="slide-control-line"></div>
                </div>
            </div>
        </div>
        <!-- main images slider container -->
    <!-- end of main images slider container -->
    <section>
      <img src="images/homebg.jpg" class="img-fluid"/>
   </section>
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Features</h2>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img width="150" src="images/aptitude_img.png"/>
                  <h4>&nbsp;Aptitude test</h4>
                  <p class="text-justify">An aptitude test is an exam used to determine an individual&#39;s skill or propensity to succeed in a given activity.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150" src="images/onlyfreshers.png"/>
                  <h4>Only for freshers</h4>
                  <p class="text-justify">Explore freshers jobs openings in your desired locations.</p>
               </center>
            </div>
             <div class="col-md-4">
               <center>
                  <img width="150" src="images/support_logo.png"/>
                  <h4>&nbsp;Support</h4>
                  <p class="text-justify">We offer dependable, on-demand support options including technical and remote support.</p>
               </center>
            </div>
         </div>
      </div>
   </section>
   <section>
      <img src="images/homebg.jpg" class="img-fluid"/>
   </section>
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Process</h2>
                  <!--<p><b>We have a Simple 3 Step Process</b></p>-->
               </center>
                <br>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img width="150" src="images/Find_jobs.png" />
                  <h4>Find Jobs</h4>
                  <p class="text-justify">&nbsp;</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150" src="images/apply.png"/>
                  <h4>Apply</h4>
                  <p class="text-justify">&nbsp;</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150" src="images/get_hired.png"/>
                  <h4>Get Hired</h4>
                  <p class="text-justify">&nbsp;</p>
               </center>
            </div>
         </div>
      </div>

        <!-- Contact us-->
       <div class="container py-4">                   
                <hr>                  
                <div>
                    <center>
                    <h3>Contact Us</h3>
                    </center>
                </div>

              <!-- contact details -->
                <div class="row contact-form py-lg-5">
                    <!-- contact left grid -->
                    <div class="col-lg-6  px-lg-5 map contact-right">
                        <div class="address">
                            <h5 class="my-3">Contact Info</h5>
                            <div class="row py-3 wthree-cicon">
                                <span class="fas fa-envelope-open mr-3"></span>
                                <a href="#">studentsrecruitmentsystem@gmail.com</a>
                            </div>
                            <div class="row py-3  wthree-cicon">
                                <span class="fas fa-phone-volume mr-3"></span>
                                <h6>+91 9987445450</h6>a
                            </div>
                            <div class="row py-3  wthree-cicon">
                                <span class="fas fa-globe mr-3"></span>
                                <a href="#">www.studentsrecruitmentsystem.com</a>
                            </div>
                            <div class="row py-3 wthree-cicon">
                                <span class="fas fa-map-marker mr-3"></span>
                                <h6>Kalyan, Maharashtra, India</h6>
                            </div>
                        </div>
                    </div>
                    <!-- contact right grid -->
                    <div class="col-lg-6 wthree-form-left mt-lg-0 mt-3">
                        <!-- contact form grid -->
                        <div class="contact-top1">
                            <h5 class="my-3">SEND US A MESSAGE</h5>
                            <form action="#" method="get" class="f-color pt-3">
                                <div class="form-group">
                                    <label for="contactusername">Name</label>
                                    <asp:TextBox ID="txtname" placeholder="Your Name" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group my-4">
                                    <label for="contactemail">Email</label>
                                    <asp:TextBox ID="txtEmail" placeholder="Enter Email ID" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                <label for="contactcomment">Your Message</label>
                                    <asp:TextBox ID="txtmsg" class="form-control" rows="5" placeholder="Message" runat="server" Height="106px"></asp:TextBox>
                                    <br />
                                    <asp:Button ID="btnsubmit" class="btn btn-danger btn-block" runat="server" Text="Send" OnClick="btnsubmit_Click" />
                                </div>
                            </div>
                              </form>
                    </div>
                </div>
                <!--  //contact right grid -->
            </div>
            <!-- //contact details  -->
       
</section>
</asp:Content>
