import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
 imports:      [CommonModule, HttpClientModule],
 declarations: [],
 exports:      [CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule]
})
export class SharedModule { }