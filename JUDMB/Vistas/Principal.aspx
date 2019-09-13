<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master_Menu.Master" CodeBehind="Principal.aspx.vb" Inherits="JUDMB.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="content-wrapper" style="min-height: 901px;">
        <section class="content-header">
          <h1>
            Menu principal
            <small>Resumen</small>
          </h1>
          <ol class="breadcrumb">
            <li class="active"><a href="#"><i class="fa fa-dashboard"></i>  Menu principal</a></li>
          </ol>
        </section>

    <!-- Main content -->
    <section class="content">
      

      <div class="row">
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-aqua"><i class="fa fa-file-o"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Total de tramites </span>
              <span class="info-box-number">1,410</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-green"><i class="fa fa-plus-square"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Tramites nuevos </span>
              <span class="info-box-number">410</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-yellow"><i class="fa fa-spinner "></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Tramites en dictaminacion</span>
              <span class="info-box-number">13,648</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
        <div class="col-md-3 col-sm-6 col-xs-12">
          <div class="info-box">
            <span class="info-box-icon bg-red"><i class="fa fa-check"></i></span>

            <div class="info-box-content">
              <span class="info-box-text">Tramites finalizados</span>
              <span class="info-box-number">93,139</span>
            </div>
            <!-- /.info-box-content -->
          </div>
          <!-- /.info-box -->
        </div>
        <!-- /.col -->
      </div>


        <div class="box box-success">
            <div class="box-header with-border">
                <h3 class="box-title">¿Que desea hacer?</h3>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                      <!-- small box -->
                      <div class="small-box bg-green">
                        <div class="inner">
                          <h3>Nuevo tramite</h3>

                          <p>Dar de alta una nueva solicitud</p>
                        </div>
                        <div class="icon">
                          <i class="fa fa-plus"></i>
                        </div>
                        <a href="#" class="small-box-footer">
                          Acceder <i class="fa fa-arrow-circle-right"></i>
                        </a>
                      </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-6 col-xs-12">
                      <!-- small box -->
                      <div class="small-box bg-teal">
                        <div class="inner">
                          <h3>Buscar tramite</h3>

                          <p>Buscar una solicitud </p>
                        </div>
                        <div class="icon">
                          <i class="fa fa-search"></i>
                        </div>
                        <a href="#" class="small-box-footer">
                          Acceder <i class="fa fa-arrow-circle-right"></i>
                        </a>
                      </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-6 col-xs-12">
                      <!-- small box -->
                      <div class="small-box bg-purple disabled">
                        <div class="inner">
                          <h3>Credito <br> Complementario</h3>

                          <p>Dar de alta un nuevo complementario </p>
                        </div>
                        <div class="icon">
                          <i class="fa fa-files-o"></i>
                        </div>
                        <a href="#" class="small-box-footer">
                          Acceder <i class="fa fa-arrow-circle-right"></i>
                        </a>
                      </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-6 col-xs-12">
                      <!-- small box -->
                      <div class="small-box bg-yellow disabled color-palette">
                        <div class="inner">
                          <h3>Modificaciones <br>al Credito </h3>

                          <p>Dar de alta una modificacion a un credito </p>
                        </div>
                        <div class="icon">
                          <i class="fa fa-pencil-square-o"></i>
                        </div>
                        <a href="#" class="small-box-footer">
                          Acceder <i class="fa fa-arrow-circle-right"></i>
                        </a>
                      </div>
                    </div>
                    <!-- ./col -->
                  </div>
            </div>
            <!-- /.box-body -->
       </div>
    </section>
    <!-- /.content -->
  </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
