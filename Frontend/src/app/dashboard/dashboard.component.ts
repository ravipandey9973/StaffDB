import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
 userlist:any=[];
 editData: any; // Add this property
 StaffId:string="";
 name:string="";
 department:string="";

constructor (private staffdata:ServicesService) 
{}
  ngOnInit(): void {
   
    this.getuser();
  }
  getuser ()
  {
    this.staffdata.getDataStaff().subscribe((data)=>{
      this.userlist=data;
      
    });
  }
deleteclick(item:any)
{
  this.staffdata.DeleteDataStaff(item.StaffId).subscribe((data)=>{
    alert("data deleted Successfully!!");
    this.getuser();
  })
}

updatedata(item:any)
{
  var val = {
    StaffId: this.editData.StaffId,
    name: this.name,
    department: this.department
  };
  this.staffdata.UpdateDataStaff(val).subscribe((data:any)=>{
    alert("data update Successfully !!");
    this.getuser();
    this.editData=null;

  })
}
openModal() {
  // Clear existing data
  this.name = "";
  this.department = "";
}




  displayedColumns: string[] = ['StaffId', 'name', 'department','edit','delete'];

}

