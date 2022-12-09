import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Router } from "@angular/router";
import { Imc } from "src/app/models/imc"
import { Usuario } from "src/app/models/usuario";

@Component({
  selector: "app-cadastrar-imc",
  templateUrl: "./cadastrar-imc.component.html",
  styleUrls: ["./cadastrar-imc.component.css"],
})
export class CadastrarImcComponent implements OnInit {
  peso!: number;
  altura!: number;
  imc!: number;
  classificacaoImc!: string;
  usuarios!: Usuario[];
  usuarioId!: string;


  constructor(private http: HttpClient, private router: Router, private _snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.http.get<Usuario[]>("https://localhost:5001/api/usuario/listar").subscribe({
      next: (usuarios) => {
        this.usuarios = usuarios;
      },
    });
  }

  cadastrar(): void {
    console.log(this.usuarioId);


    let imc: Imc = {
      peso: this.peso,
      altura: this.altura,
      imc: this.imc,
      classificacaoImc: this.classificacaoImc,
      usuarioId: this.usuarioId,
    };

    this.http.post<Imc>("https://localhost:5001/api/imc/cadastrar", imc).subscribe({
      next: (imc) => {
        this._snackBar.open("Imc cadastrada!", "Ok!", {
          horizontalPosition: "right",
          verticalPosition: "top",
        });
        this.router.navigate(["pages/imc/listar"]);
      },
    });
  }
}
