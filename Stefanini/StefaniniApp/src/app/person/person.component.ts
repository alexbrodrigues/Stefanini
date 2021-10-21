import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Person } from '../_models/Person';
import { PersonService } from '../_services/Person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  personsFilters: Person[] = [];
  persons: Person[] = [];
  person!: Person;

  titulo = 'Pessoas';
  modoSalvar = 'post';
  bodyDeletePerson = '';
  dataAtual = '';
  _filtroLista!: string;

  registerForm: FormGroup | any;

  constructor(
    private personService: PersonService,
    private modalService: BsModalService,
    private fb: FormBuilder,
    private toastr: ToastrService) { }

    get filtroLista(): string {
      return this._filtroLista;
    }

    set filtroLista(value: string) {
      this._filtroLista = value;
      this.personsFilters = this.filtroLista
      ? this.filtrarPersons(this.filtroLista)
      : this.persons;
    }

    filtrarPersons(filtrarPor: string): Person[]  {
      filtrarPor = filtrarPor.toLocaleLowerCase();
      return this.persons.filter(
        (person: any) => person.name.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        );
      }

      newPerson(template: any) {
        this.modoSalvar = 'post';
        this.openModal(template);
      }

      openModal(template: any) {
        this.registerForm.reset();
        template.show();
      }

      editEvento(person: Person, template: any) {
        this.modoSalvar = 'put';
        this.openModal(template);
        this.person = Object.assign({}, person);
        this.registerForm.patchValue(this.person);
      }

      ngOnInit() {
        this.validation();
        this.getPersons();
      }

      validation() {
        this.registerForm = this.fb.group({
          name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]]
        });
      }

      getPersons() {
        this.dataAtual = new Date().getMilliseconds().toString();
        this.personService.getAllPerson().subscribe(
          (_persons: Person[]) => {
            this.persons = _persons;
            this.personsFilters = this.persons;
          },
          (error) => {
            this.toastr.error(`Erro ao tentar carregar pessoas: ${error}`);
          }
          );
        }

        salvarAlteracao(template: any) {
          if (this.registerForm.valid) {
            if (this.modoSalvar === 'post') {
              this.person = Object.assign({}, this.registerForm.value);

              this.personService.postEvento(this.person).subscribe(
                (newPerson: Person) => {
                  template.hide();
                  this.getPersons();
                  this.toastr.success('Inserido com Sucesso!');
                }, error => {
                  this.toastr.error(`Erro ao Inserir: ${error}`);
                }
                );
              } else {
                this.person = Object.assign({ id: this.person.id }, this.registerForm.value);

                this.personService.putPerson(this.person).subscribe(
                  () => {
                    template.hide();
                    this.getPersons();
                    this.toastr.success('Editado com Sucesso!');
                  }, error => {
                    this.toastr.error(`Erro ao Editar: ${error}`);
                  }
                  );
                }
              }
            }

            confirmeDelete(template: any) {
              this.personService.deletePerson(this.person.id).subscribe(
                () => {
                  template.hide();
                  this.getPersons();
                  this.toastr.success('Deletado com sucesso!');
                }, error => {
                  this.toastr.error(`Erro ao deletar: ${error}`);
                }
                );
              }

              deletePerson(person: Person, template: any) {
                this.openModal(template);
                this.person = person;
                this.bodyDeletePerson = `Tem certeza que deseja excluir a Pessoa: ${person.name}, Código: ${person.id}`;
              }

}
