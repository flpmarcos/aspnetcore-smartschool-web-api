import { Component, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject, takeUntil } from 'rxjs';

import { Aluno } from '../../models/Aluno';
import { Professor } from '../../models/Professor';

import { AlunoService } from 'src/app/services/aluno.service';
import { ProfessorService } from 'src/app/services/professor.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit , OnDestroy {


  public modalRef: BsModalRef;
  public alunoForm: FormGroup;
  public titulo = 'Alunos';
  public alunoSelecionado: Aluno;
  public textSimple: string;
  public profsAlunos: Professor[];

  private unsubscriber = new Subject();

  public alunos: Aluno[];
  public aluno: Aluno;
  public msnDeleteAluno: string;
  public modeSave = 'post';

  openModal(template: TemplateRef<any>, alunoId: number) {
    this.professoresAlunos(template, alunoId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  professoresAlunos(template: TemplateRef<any>, id: number) {
    this.spinner.show();
    this.professorService.getByAlunoId(id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((professores: Professor[]) => {
        this.profsAlunos = professores;
        this.modalRef = this.modalService.show(template);
      }, (error: any) => {
        this.toastr.error('Professores não carregados!');
        console.log(error.message);
        this.spinner.hide();
      }, () => this.spinner.hide()
    );
  }

  constructor(
    private alunoService: AlunoService,
    private route: ActivatedRoute,
    private professorService: ProfessorService,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {
    this.criarForm();
  }

  ngOnInit() {
    this.carregarAlunos();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next(true);
    this.unsubscriber.complete();
  }

  criarForm() {
    this.alunoForm = this.fb.group({
      id: [0],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  saveAluno() {
    if (this.alunoForm.valid) {
      this.spinner.show();

      if (this.modeSave === 'post') {
        this.aluno = {...this.alunoForm.value};
      } else {
        this.aluno = {id: this.alunoSelecionado.id, ...this.alunoForm.value};
      }

      this.alunoService[this.modeSave](this.aluno)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.carregarAlunos();
            this.toastr.success('Aluno salvo com sucesso!');
          }, (error: any) => {
            this.toastr.error(`Erro: Aluno não pode ser salvo!`);
            console.error(error);
          }, () => this.spinner.hide()
        );

    }
  }

  trocarEstado(aluno : Aluno)  {
    this.alunoService.trocarEstado(aluno.id,aluno.ativo)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.carregarAlunos();
            this.toastr.success('Aluno salvo com sucesso!');
          }, (error: any) => {
            this.toastr.error(`Erro: Aluno não pode ser salvo!`);
            console.error(error);
          }, () => this.spinner.hide()
        );
  }

  carregarAlunos() {
    const alunoId = +this.route.snapshot.paramMap.get('id');

    this.spinner.show();
    this.alunoService.getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((alunos: Aluno[]) => {
        this.alunos = alunos;

        if (alunoId > 0) {
          this.alunoSelect(alunoId);
        }

        this.toastr.success('Alunos foram carregado com Sucesso!');
      }, (error: any) => {
        this.toastr.error('Alunos não carregados!');
        console.log(error);
        this.spinner.hide();
      }, () => this.spinner.hide()
    );
  }

  alunoSelect(alunoId: number) : void {
    this.modeSave = 'patch';
    this.alunoService.getById(alunoId).subscribe(
      // Sucess
      (alunoReturn) => {
        this.alunoSelecionado = alunoReturn;
        this.toastr.success('Aluno carregado!');
        this.alunoForm.patchValue(this.alunoSelecionado);
      },
      // Erro
      (error) => {
        this.toastr.error('Aluno não carregado!');
        console.error(error);
        this.spinner.hide();
      },
      // After
      () => this.spinner.hide()
    );
  }



 voltar() {
    this.alunoSelecionado = null;
  }

}
