import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Person } from 'src/app/_models/Person';
import { PersonPhone } from 'src/app/_models/PersonPhone';
import { PhoneNumberType } from 'src/app/_models/PhoneNumberType';
import { PersonService } from 'src/app/_services/Person.service';
import { PhoneNumberTypeService } from 'src/app/_services/phoneNumberType.service';

@Component({
  selector: 'app-personEdit',
  templateUrl: './personEdit.component.html',
  styleUrls: ['./personEdit.component.css']
})
export class PersonEditComponent implements OnInit {

  public customPatterns = { A: { pattern: new RegExp('') } };

  registerForm: FormGroup | any;

  person: Person = new Person();

  numberTypes: PhoneNumberType[];

  titulo = 'Editar Pessoa';

  get phones(): FormArray {
    return <FormArray>this.registerForm.get('phones');
  }

  constructor(
    private personService: PersonService,
    private phoneNumberTypeService: PhoneNumberTypeService,
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: ActivatedRoute) { }

  ngOnInit() {
    this.validation();
    this.carregarPerson();
    this.getPhoneNumberType();
  }

  getPhoneNumberType() {
    return this.phoneNumberTypeService.getAllPhoneNumberType().subscribe(
      (_numberTypes: PhoneNumberType[]) => {
        this.numberTypes = _numberTypes;
      },
      (error) => {
        this.toastr.error(`Erro ao tentar carregar pessoas: ${error}`);
      }
    );
  }

  validation() {
    this.registerForm = this.fb.group({
      id: [],
      name: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      phones: this.fb.array([])
    });
  }

  carregarPerson() {
    const idPerson = +this.router.snapshot.paramMap.get('id');
    this.personService.getPersonById(idPerson)
      .subscribe(
        (person: Person) => {
          this.person = Object.assign({}, person);
          this.registerForm.patchValue(this.person);

          this.person.phones.forEach(phone => {
            this.phones.push(this.criarPhone(phone));
          });
        }
      );
  }

  criarPhone(phone: any): FormGroup {
    return this.fb.group({
      phoneNumber: ['', [Validators.required]],
      phoneNumberType: ['', [Validators.required]]
    });
  }

  adicionarPhone() {
    this.phones.push(this.criarPhone({ id: 0 }));
  }

  removerPhone(id: number) {
    const personPhone: PersonPhone[] = [];
    this.phones.removeAt(id);
  }

  salvarPerson() {
    this.person = Object.assign({ id: this.person.businessEntityID }, this.registerForm.value);

    this.personService.putPerson(this.person).subscribe(
      () => {
        this.toastr.success('Editado com Sucesso!');
      }, error => {
        this.toastr.error(`Erro ao Editar: ${error}`);
      }
    );
  }

}
