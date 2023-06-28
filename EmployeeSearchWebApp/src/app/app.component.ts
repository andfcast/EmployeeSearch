import { Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ApiResponse } from './classes/apiResponse';
import { Employee } from './classes/employee';
import { EmployeeService } from './services/employee.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {  
  title = 'EmployeeSearchWebApp';
  cols:string[] = ['Id','Name', 'Salary', 'AnnualSalary','Age', 'Image']; 
  isInfoLoaded = false;
  lstEmployees : Employee[];
  searchForm : FormGroup;
  searchPattern = "/^(\s*|\d+)$/";
  dataSource: any;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  constructor(private fb: FormBuilder,
    private service:EmployeeService,     
    private router: Router){
      this.searchForm = this.fb.group({
        searchText:['',],        
      }
      );
  }

  ngOnInit(){
    this.lstEmployees = [];  
    this.dataSource = new MatTableDataSource<Employee>(this.lstEmployees);  
  }

  ngAfterViewInit(){
    
    this.dataSource.paginator = this.paginator;
  }
  
  Search(){
    let employeeId = this.searchForm.value.searchText;    
    this.service.Search(employeeId).subscribe((res:ApiResponse) =>{      
      if(res.data != null){
        this.lstEmployees = [];
        res.data.forEach((x:Employee) => {
          this.lstEmployees.push(x);
        });        
        this.isInfoLoaded = true;
        this.dataSource = new MatTableDataSource<Employee>(this.lstEmployees);
        this.dataSource.paginator = this.paginator;  
      }
      else{
        Swal.fire({
          title: '¡Error!',
          text: 'No se pudieron cargar datos. Favor contactar al administrador',
          icon: 'error',
          timer:2000,        
          confirmButtonText: 'Aceptar'
        })
      }
      
    });
  }
}
