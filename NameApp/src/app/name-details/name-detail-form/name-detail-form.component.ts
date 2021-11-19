import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { NameDetail } from 'src/app/shared/name-detail.model';
import { NameDetailService } from 'src/app/shared/name-detail.service';

@Component({
  selector: 'app-name-detail-form',
  templateUrl: './name-detail-form.component.html',
  styles: [
  ]
})
export class NameDetailFormComponent implements OnInit {

  constructor(public service:NameDetailService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    this.service.postNameDetail().subscribe({
      next: v =>{
        this.resetForm(form);
        this.toastr.success('Submitted successfully', 'Name Detail Registered');
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete') 
  })
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new NameDetail();
  }

}
