import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, NgForm, Validators } from '@angular/forms';
import { EmployeebalanceService } from '../../Services/employeebalance.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Vacationview } from '../../Models/vacationview';
import { NotificationService } from 'src/app/Services/notification.service';
@Component({
  selector: 'app-employeebalance',
  templateUrl: './employeebalance.component.html',
  styleUrls: ['./employeebalance.component.css']
})
export class EmployeebalanceComponent implements OnInit{
  allVacationviews:any =  [];
  employeebalanceForm: any;
  vacationBalance: any;

  errorstatus: number = 200;
  message: string = "Something Went Wrong..";
  title: string = "vacation Form";

  constructor(private employeebalanceService:EmployeebalanceService,
              private router:Router,
              private formbulider: FormBuilder,
              private notificationService: NotificationService)
              { }

  ngOnInit(): void {
    this.loadAllEmployeebalances();
  }

  ngAfterViewInit(): void {
    this.loadAllEmployeebalances();
  }

  changeEmployeeBalance(vacationviews: Vacationview[]) {
    this.employeebalanceService.updateEmployeeBalances(vacationviews).subscribe(
      data => {
        console.log("vacationview balance: " + vacationviews[2].balance);
        this.loadAllEmployeebalances();
      }, error =>{
        console.log("error on delete: " + error.status);
        this.errorstatus = error.status;
        this.notificationService.showError(this.message, this.title);
      });
      console.log(this.allVacationviews);
  }

  loadAllEmployeebalances() {
    this.employeebalanceService.getAllEmployeeBalance().subscribe(Vacationview =>{
      this.allVacationviews = Vacationview;
    });
  }

  deleteEmployeebalance(employeebalanceId: number) {
    if (confirm("Are you sure you want to delete this ?")) {
    this.employeebalanceService.deleteEmployeeBalanceById(employeebalanceId).subscribe(data => {
      this.loadAllEmployeebalances();
    }, error =>{
        console.log("error on delete: " + error.status);
        this.errorstatus = error.status;
        this.notificationService.showError(this.message, this.title);
    });
  }
 }

 convertBalance(balance: number){
  return balance;
 }

  compare(str1 : string, str2 : string){
    return str1.localeCompare(str2) == 0;
 }

 trackByIndex(index: number, obj: any): any {
  return index;
  }

}
