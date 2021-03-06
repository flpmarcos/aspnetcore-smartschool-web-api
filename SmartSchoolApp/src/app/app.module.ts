import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { AlunosComponent } from './components/alunos/alunos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { ProfessoresComponent } from './components/professores/professores.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { TituloComponent } from './components/shared/titulo/titulo.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ProfessoresAlunosComponent } from './components/alunos/professores-alunos/professores-alunos.component';
import { ProfessorDetalheComponent } from './components/professores/professor-detalhe/professor-detalhe.component';
import { AlunosProfessoresComponent } from './components/professores/alunos-professores/alunos-professores.component';

@NgModule({
  declarations: [
    AppComponent,
    AlunosComponent,
    ProfessoresAlunosComponent,
    DashboardComponent,
    PerfilComponent,
    ProfessoresComponent,
    ProfessorDetalheComponent,
    AlunosProfessoresComponent,
    NavComponent,
    TituloComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    ModalModule.forRoot(),
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar:true,
      closeButton: true
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
