import { TableroComponent } from './tablero/tablero.component';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

export const routes: Routes =  [
  {
    path: '',
    component: TableroComponent,
    data: { pageTitle: 'Tablero' },
    children: [
    ]
  },
  { path: '**', redirectTo: 'error/error404'}
];

export const AppRoutingModule: ModuleWithProviders = RouterModule.forRoot(routes, {
  useHash: true,
});