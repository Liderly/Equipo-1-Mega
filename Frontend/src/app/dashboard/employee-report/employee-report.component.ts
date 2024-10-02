import { CommonModule, NgFor, NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataServiceService } from '../../services/dataService/data-service.service';

//Requerimiento para generar pdf
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';



interface Trabajo {
  id: number;
  descripcion: string;
  puntos: number;
}

interface DatosEmpleado {
  num_empleado: string;
  nombre: string;
  puntaje: number;
  dinero: number;
  trabajos: Trabajo[];
}

@Component({
  selector: 'app-employee-report',
  standalone: true,
  imports: [CommonModule, NgFor, NgIf],
  templateUrl: './employee-report.component.html',
  styleUrls: ['./employee-report.component.css'],
})
export class EmployeeReportComponent implements OnInit {
  datos: any = {};
  num_empleado: any = {};
  showBody: boolean = false;
  lista_reporte_empleado: any = {};
  lista_datos_generales: any = {};

  constructor(
    private dataService: DataServiceService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const datosGuardados = localStorage.getItem('buscar_reporte_empleado');
    this.num_empleado = datosGuardados ? JSON.parse(datosGuardados) : null;

    this.dataService
      .getDataPuntosTecnico(this.num_empleado.num_empleado)
      .subscribe({
        next: (data) => {
          this.lista_reporte_empleado = data.filter(
            (item: any) => item.estatus === 'Instalado'
          );
          this.lista_datos_generales = this.lista_reporte_empleado[0];
          //console.log(this.lista_reporte_empleado);
        },
        error: (err) => {
          console.error('Error al insertar registro:', err);
          alert('Numero de empleado no encontrado, inténtenlo de nuevo');
          this.router.navigate(['/dashboard/employee']);
        },
      });

    // Aquí normalmente cargarías los datos del empleado, por ejemplo, de un servicio
    this.datos = {
      num_empleado: this.num_empleado,
    };
  }

  toggleBody(): void {
    this.showBody = !this.showBody;
  }


  generarPDF() {
    const element = document.getElementById('contenido-a-imprimir');
    if (element) {
      html2canvas(element).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');

        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth();
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

        pdf.addImage(imgData, 'PNG', 0, 0, pdfWidth, pdfHeight);
        pdf.save('reporte.pdf');
      });
    }
  }

}
