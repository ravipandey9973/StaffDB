import { Component, OnInit } from '@angular/core';
import { ServicesService } from '../services.service';

@Component({
  selector: 'app-entry',
  templateUrl: './entry.component.html',
  styleUrl: './entry.component.css'
})
export class EntryComponent implements OnInit{
userlist:any[]=[];
StaffId:string="";
name:string="";
department:string="";
  constructor(private service:ServicesService) {}
  ngOnInit(): void {
    
    
  }
  adduser()
  {var val= {
    StaffId:this.StaffId,
    name:this.name,
    department:this.department
  }
    this.service.AddDataStaff(val).subscribe((data)=>{
    this.userlist=data;
    alert("added sucessfully")  
    })
  }
  
}
