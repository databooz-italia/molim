import { Component } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PazienteDTO, EsamePazienteDTO, PatologiaDTO, DiagnosiDTO, PredizioneDTO, FeatureDTO, AlgoritmoDTO, FeatureEsameDTO } from '../../services/api.client';
import { PazientiService } from '../../services/pazienti.service';
import { finalize } from 'rxjs/operators';
import { TranslateService } from '@ngx-translate/core';
import Swal from 'sweetalert2';
import { DatePipe } from '@angular/common';
import { PatologieService } from '../../services/patologie.service';
import { NgxSpinnerService } from "ngx-spinner";
import { AlgoritmiService } from '../../services/algoritmi.service';

@Component({
  templateUrl: 'patients.component.html'
})
export class PatientsMasterComponent implements OnInit {
  ColumnMode = ColumnMode;
  SelectionType = SelectionType;
  isBusy: boolean = false;
  error: string;

  textFilter: string;
  selected: any[];
  selectedExams: any[];

  patientForm: FormGroup;
  patients: PazienteDTO[];

  showingPatients: any[];

  detail: PazienteDTO;
  detailOriginalId: string;

  patientExams: EsamePazienteDTO[];

  selectedPathology: any;
  pathologies: PatologiaDTO[] = [];

  exams: any = [];
  showingExams = [];
  selectedExam;

  diagnosisList: any = [];
  showingDiagnosis: DiagnosiDTO[] = [];

  allAlgorithms = [/*{
    id: 0,
    desc: 'AlzheimerDementia monolaterale/bilaterale',
    idPatologia: 'NAD'
  },
  {
    id: 1,
    desc: 'AlzheimerDementia diagnosi della patologia',
    idPatologia: 'NAD'
  },
  {
    id: 2,
    desc: 'AlzheimerDementia amiloide negativo/positivo',
    idPatologia: 'NAD'
  },
  {
    id: 3,
    desc: 'OncoBreast marker ER-/ER+',
    idPatologia: 'ONB'
  },
  {
    id: 4,
    desc: 'OncoBreast marker HER2-/HER2+',
    idPatologia: 'ONB'
  },
  {
    id: 5,
    desc: 'OncoBreast marker KI67-/KI67+',
    idPatologia: 'ONB'
  },
  {
    id: 6,
    desc: 'OncoBreast marker PR-/PR+',
    idPatologia: 'ONB'
  },
  {
    id: 7,
    desc: 'OncoColon coinvolgimento dei linfonodi',
    idPatologia: 'ONC'
  }*/];

  algorithms = [];

  idImmagineMaster: number;

  diagnosisColumns = [
    { prop: 'data', name: 'PATIENTS.DETAIL.DIAGNOSIS_DATE', flexGrow: 1, pipe: this.datePipe() },
    { prop: 'esito', name: 'PATIENTS.DETAIL.DIAGNOSIS_RESULT', flexGrow: 1 }
  ];

  predictionsList: any = [];
  showingPredictions: PredizioneDTO[] = [];

  predictionsColumns = [
    { prop: 'descrizioneAlgoritmo', name: 'PATIENTS.DETAIL.PREDICTION_ALGORITHM', flexGrow: 1 },
    { prop: 'dataRichiesta', name: 'PATIENTS.DETAIL.PREDICTION_REQUEST_DATE', flexGrow: 1, pipe: this.datePipe() },
    { prop: 'esitoPredizione', name: 'PATIENTS.DETAIL.PREDICTION_RESULT', flexGrow: 1 }
  ];

  showAddImage: boolean;
  showFeatureExtraction: boolean = false;

  newExamType: string;
  newExamDate: Date;

  newDiagnosisDate: Date;
  newDiagnosisResult: string;

  showAddExam: boolean;
  showAddDiagnosis: boolean;

  imageForFeaturesUpload: any;
  showFeaturesUpload: boolean;
  idImageForFeaturesUpload: string;

  showPredictionRequest: boolean;
  idImageForPrediction: string;
  idRoiForFeatureExtraction: number;

  imageForFeatureExtraction: any;
  idSelectedPredictionAlgorithm: any;

  features: FeatureDTO[];

  selectedFeatureExtractionAlgorithm: any;

  constructor(
    private formBuilder: FormBuilder,
    private algoritmi: AlgoritmiService,
    private pazienti: PazientiService,
    private patologie: PatologieService,
    private translate: TranslateService,
    private _datePipe: DatePipe,
    private spinner: NgxSpinnerService) {
    this.patientForm = this.formBuilder.group({
      idPaziente: ['', Validators.required],
      cognomePaziente: ['', Validators.required],
      nomePaziente: ['', Validators.required],
      sesso: ['', Validators.required],
      annoNascita: ['', Validators.required],
      city: ['', Validators.required],
      education: ['', Validators.nullValidator],
      indirizzoMail: ['', Validators.nullValidator],
      numeroCellulare: ['', Validators.nullValidator]
    });

    /*
    this.pathologies[0].tipiEsami[0].features
    let t: EsamePazienteDTO = undefined;
    t.idTipoEsame
    */

    for (let c of this.columns)
      c.name = translate.instant(c.name);

    for (let c of this.examsColumns)
      c.name = translate.instant(c.name);

    for (let c of this.imagesColumns)
      c.name = translate.instant(c.name);

    for (let c of this.diagnosisColumns)
      c.name = translate.instant(c.name);

    for (let c of this.predictionsColumns)
      c.name = translate.instant(c.name);
  }

  columns = [
    { prop: 'idPaziente', name: 'PATIENTS.LIST.ID', flexGrow: 1 },
    { prop: 'cognomePaziente', name: 'PATIENTS.LIST.FULL_NAME', flexGrow: 1 },
    { prop: 'sesso', name: 'PATIENTS.LIST.GENDER', flexGrow: 1 },
    { prop: 'annoNascita', name: 'PATIENTS.LIST.YEAR_OF_BIRTH', flexGrow: 1 }];

  examsColumns = [
    { prop: 'descrizioneTipoEsame', name: 'PATIENTS.DETAIL.EXAM_TYPE', flexGrow: 1 },
    { prop: 'data', name: 'PATIENTS.DETAIL.EXAM_DATE', flexGrow: 1, pipe: this.datePipe() },
    { prop: 'features', name: 'PATIENTS.DETAIL.EXAM_NUM_FEATURES', flexGrow: 1, pipe: this.featuresPipe() }
  ];

  imagesColumns = [
    { prop: 'nome', name: 'PATIENTS.DETAIL.EXAM_FILE_NAME', flexGrow: 1 },
    { prop: 'dimensione', name: 'PATIENTS.DETAIL.EXAM_FILE_SIZE', flexGrow: 1 },
    { prop: 'dataCaricamento', name: 'PATIENTS.DETAIL.EXAM_FILE_DATE', flexGrow: 1, pipe: this.datePipe() }
  ];

  datePipe() {
    return { transform: (value) => this._datePipe.transform(value, 'dd/MM/yyyy') };
  }

  featuresPipe() {
    return { transform: (value) => (value || []).length };
  }

  valuePipe() {
    return { transform: (value) => { console.log(value); if (value == 0) return new Number(value.valore); return value.valore } };
  }

  ngOnInit(): void {
    this.refreshList();
    this.refreshPathologies();
    this.refreshAlgorithms();
  }

  requestFeatureExtraction() {
    Swal.fire({
      icon: 'success',
      title: 'OK',
      text: 'Request sent!'
    });
  }

  downloadImage(idImage) {

    let imageObj = this.selectedExam.immagini.find(x => x.id == idImage);

    console.log(imageObj);
    
    this.pazienti.downloadFileImmagine(this.detail.idPaziente, this.selectedExam.idEsame, idImage)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        //new Blob([res.data], { type: 'image/png' });
        /*
        var url = window.URL.createObjectURL(res.data);
        window.open(url);
        */

        var newBlob = new Blob([res.data], { type: "application/octet-stream" });
            
            // IE doesn't allow using a blob object directly as link href
            // instead it is necessary to use msSaveOrOpenBlob
            if (window.navigator && (window.navigator as any).msSaveOrOpenBlob) {
                (window.navigator as any).msSaveOrOpenBlob(newBlob, imageObj.nome);
                return;
            }
            
            // For other browsers: 
            // Create a link pointing to the ObjectURL containing the blob.
            const data = window.URL.createObjectURL(newBlob);
            
            var link = document.createElement('a');
            link.href = data;
            link.download = imageObj.nome;
            // this is necessary as link.click() does not work on the latest firefox
            link.dispatchEvent(new MouseEvent('click', { bubbles: true, cancelable: true, view: window }));
            
            setTimeout(function () {
                // For Firefox it is necessary to delay revoking the ObjectURL
                window.URL.revokeObjectURL(data);
                link.remove();
            }, 100);
      },
        error => {
          this.error = error;
        }
      );
  }

  addFeature() {
    let fs = [...this.selectedExam.features];
    fs.unshift({});

    this.selectedExam.features = fs;
  }

  refreshList() {
    this.isBusy = true;

    this.pazienti.getList()
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res: PazienteDTO[]) => {
        this.patients = this.showingPatients = res;
        this.selected = [];
      },
        error => {
          this.error = error;
        }
      );
  }

  refreshExams() {
    if (!this.selected || this.selected.length <= 0)
      return;

    this.isBusy = true;
    this.pazienti.getExams(this.selected[0].idPaziente)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        console.log(res);
        this.exams = res;
      },
        error => {
          this.error = error;
        }
      );
  }

  refreshAlgorithms() {
    this.isBusy = true;

    this.algoritmi.getList()
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res: AlgoritmoDTO[]) => {
        this.allAlgorithms = res.map(x => { return { id: x.id, desc: x.descrizione, idPatologia: x.idPatologia }; });
      },
        error => {
          this.error = error;
        }
      );
  }

  refreshPathologies() {
    this.isBusy = true;

    this.patologie.getList()
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res: PatologiaDTO[]) => {
        this.pathologies = res;
      },
        error => {
          this.error = error;
        }
      );
  }

  selectPathology(p) {
    this.selectedPathology = p;
    this.selectedExam = undefined;

    //TODO
    this.algorithms = this.allAlgorithms.filter(x => x.idPatologia == p.id);

    this.showingExams = this.exams[p.id] || [];//).filter(x => x.idPatologia == p.id);
    this.showingDiagnosis = this.diagnosisList[p.id] || [];
    this.showingPredictions = this.predictionsList[p.id] || [];
    console.log(this.showingExams);
    console.log(this.exams);
    //refresh exams
  }

  getPathologyExamNumber(p) {

    if (this.exams && this.exams[p.id])
      return this.exams[p.id].length;

    return 0;
  }

  filter() {
    if (!this.textFilter)
      this.textFilter = "";

    this.showingPatients = this.patients.filter(x =>
      this.textFilter == ""
      ||
      (x.idPaziente && x.idPaziente.toLowerCase().includes(this.textFilter.toLowerCase()))
      ||
      (x.cognomePaziente && x.cognomePaziente.toLowerCase().includes(this.textFilter.toLowerCase()))
      ||
      (x.nomePaziente && x.nomePaziente.toLowerCase().includes(this.textFilter.toLowerCase()))
    );
  }

  saveFeatureEsame(row) {
    this.pazienti.saveFeatureEsame(this.detail.idPaziente, this.selectedExam.idEsame, row)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        let translated = this.translate.instant('MESSAGES.Success');

        Swal.fire({
          icon: 'success',
          title: translated
        });
      },
        error => {
          this.error = error;
        }
      );
  }

  onActivate(event) {
    if (event.type == "dblclick") {
      console.log('Activate Event', event);
      this.showDetail(event.row);
    }
  }

  onExamActivate(event) {
    if (event.type != "dblclick")
      return;

    console.log(this.selectedExams);
    this.selectedExam = undefined;

    setTimeout(() => {
      this.selectedExam = this.selectedExams[0];

      this.features = this.selectedPathology.tipiEsami.find(x => x.idTipologiaEsame == this.selectedExam.idTipoEsame).features;
      console.log(this.features);
    });

  }

  uploadFeatures(files) {
    if (files.length === 0) {
      return;
    }

    let featuresFile = <File>files[0];

    if (featuresFile) {

      let idImage = null;
      let idRoi = null;

      if (this.idImageForFeaturesUpload.substr(0, 2) == 'I_')
        idImage = Number(this.idImageForFeaturesUpload.substr(2, this.idImageForFeaturesUpload.length - 2));

      if (this.idImageForFeaturesUpload.substr(0, 2) == 'R_')
        idRoi = Number(this.idImageForFeaturesUpload.substr(2, this.idImageForFeaturesUpload.length - 2));

        console.log(idImage);
        console.log(idRoi);
        console.log(this.idImageForFeaturesUpload);

      var reader = new FileReader();
      reader.readAsText(featuresFile, "UTF-8");

      let pazienti = this.pazienti;
      let idPaziente = this.detail.idPaziente;
      let idEsame = this.selectedExam.idEsame;
      let translate = this.translate;
      let imageForFeaturesUpload = this.imageForFeaturesUpload;
      let exam = this.selectedExam;

      console.log(imageForFeaturesUpload);

      reader.onload = function (evt) {

        let resObj = JSON.parse(evt.target.result as string);

        console.log(resObj);

        let featuresEsame: FeatureEsameDTO[] = Object.keys(resObj).map(x => {
          return new FeatureEsameDTO({
            idFeature: x,
            idImmagine: idImage,
            idROI: idRoi,
            valore: resObj[x].toString(),
            dataFineValidita: null,
            dataInizioValidita: null,
            descrizione: null,
            tipoValore: null,
          });
        });
        
        pazienti.saveFeaturesEsame(idPaziente, idEsame, featuresEsame)
          .pipe(finalize(() => {

          }))
          .subscribe((res) => {
            let translated = translate.instant('MESSAGES.Success');

            imageForFeaturesUpload.features = featuresEsame;
            exam.features = featuresEsame;

            Swal.fire({
              icon: 'success',
              title: translated
            });
          },
            error => {
              Swal.fire({
                icon: 'error',
                title: 'Errore'
              });
            }
          );                 
      }

      /*
      
    };
    */

      reader.onerror = function (evt) {

      };

    }
  }

  uploadImageFileInput(files) {
    if (files.length === 0) {
      return;
    }

    let fileToUpload = <File>files[0];
    console.log(fileToUpload);
    let formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    this.spinner.show();

    if (!this.idImmagineMaster)
      this.pazienti.uploadFileImmagine(this.detail.idPaziente, this.selectedExam.idEsame, fileToUpload)
        .pipe(finalize(() => {
          this.isBusy = false;
          this.spinner.hide();
        }))
        .subscribe((res) => {
          let im = [...this.selectedExam.immagini];
          im.unshift({
            dataCaricamento: new Date(),
            nome: fileToUpload.name,
            dimensione: fileToUpload.size,
            id: res
          });

          this.selectedExam.immagini = im;

          let translated = this.translate.instant('MESSAGES.Success');

          Swal.fire({
            icon: 'success',
            title: translated
          });
        },
          error => {
            this.error = error;
          }
        );
    else
      this.pazienti.uploadFileRoi(this.idImmagineMaster, fileToUpload)
        .pipe(finalize(() => {
          this.isBusy = false;
          this.idImmagineMaster = undefined;
          this.spinner.hide();
        }))
        .subscribe((res) => {
          let immagine = this.selectedExam.immagini.find(i => i.id == this.idImmagineMaster);

          if (immagine) {
            if (!immagine.regioniDiInteresse)
              immagine.regioniDiInteresse = [];

            immagine.regioniDiInteresse.push({
              nomeFile: fileToUpload.name,
              id: res
            });
          }

          let translated = this.translate.instant('MESSAGES.Success');

          Swal.fire({
            icon: 'success',
            title: translated
          });
        },
          error => {
            this.error = error;
          }
        );

    this.showAddImage = false;
  }

  showDetail(patient) {
    this.selectedPathology = undefined;
    this.selectedExam = undefined;
    this.idImageForPrediction = undefined;
    this.idSelectedPredictionAlgorithm = undefined;
    this.idImageForFeaturesUpload = undefined;
    this.detail = patient;
    this.patientForm.patchValue(this.detail);
    this.detailOriginalId = this.detail.idPaziente;

    this.pazienti.getExams(patient.idPaziente)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        this.exams = res;
        this.selectedExams = [];
      },
        error => {
          this.error = error;
        }
      );

    this.pazienti.getDiagnosi(patient.idPaziente)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        this.diagnosisList = res;
      },
        error => {
          this.error = error;
        }
      );

    this.pazienti.getPredizioni(patient.idPaziente)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        this.predictionsList = res;
      },
        error => {
          this.error = error;
        }
      );
  }

  requestPrediction() {
    /*Swal.fire({
      icon: 'success',
      title: 'OK',
      text: 'Request sent!'
    });
    */

    //this.spinner.show();

    let idImage = null;
    let idRoi = null;

    if (this.idImageForPrediction.substr(0, 2) == 'I_')
      idImage = Number(this.idImageForPrediction.substr(2, this.idImageForPrediction.length - 2));

    if (this.idImageForPrediction.substr(0, 2) == 'R_')
      idRoi = Number(this.idImageForPrediction.substr(2, this.idImageForPrediction.length - 2));

    this.pazienti.requestPredizione(this.detail.idPaziente, this.selectedPathology.id, idImage, idRoi, Number(this.idSelectedPredictionAlgorithm))
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe((res) => {
        let translated = this.translate.instant('MESSAGES.Success');

        this.predictionsList = res;
        this.showingPredictions = this.predictionsList[this.selectedPathology.id] || [];

        Swal.fire({
          icon: 'success',
          title: translated
        });
      },
        error => {
          Swal.fire({
            icon: 'error',
            title: 'Error during prediction!'
          });
        }
      );
  }

  saveNewDiagnosis() {
    this.pazienti.saveDiagnosi(this.detail.idPaziente, this.selectedPathology.id, new Date(this.newDiagnosisDate), this.newDiagnosisResult)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        if (!this.diagnosisList[this.selectedPathology.id])
          this.diagnosisList[this.selectedPathology.id] = [];

        let ex = [...this.diagnosisList[this.selectedPathology.id]];
        ex.unshift(new DiagnosiDTO({
          data: this.newDiagnosisDate,
          esito: this.newDiagnosisResult
        }));

        this.diagnosisList[this.selectedPathology.id] = ex;

        this.showingDiagnosis = this.diagnosisList[this.selectedPathology.id];//.filter(x => x.idPatologia == this.selectedPathology.id);

        this.showAddDiagnosis = false;

        let translated = this.translate.instant('MESSAGES.Success');

        Swal.fire({
          icon: 'success',
          title: translated
        });
      },
        error => {
          this.error = error;
        }
      );
  }

  saveNewExam() {
    console.log(this.newExamDate);

    let examTypeDescription: string;

    // selectedPathology.tipiEsami

    let tipoEsame: any;
    tipoEsame = this.selectedPathology.tipiEsami.filter(x => x.idTipologiaEsame == this.newExamType);
    if (!tipoEsame || tipoEsame.length != 1) {
      Swal.fire({
        icon: 'error',
        title: 'Error during exam type retrieving!'
      });

      return;
    }

    console.log(tipoEsame);

    this.pazienti.saveEsame(this.detail.idPaziente, this.selectedPathology.id, this.newExamType, new Date(this.newExamDate))
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res) => {
        if (!this.exams[this.selectedPathology.id])
          this.exams[this.selectedPathology.id] = [];

        let ex = [...this.exams[this.selectedPathology.id]];
        ex.unshift(new EsamePazienteDTO({
          data: this.newExamDate,
          idEsame: res,
          idPatologia: this.selectedPathology.id,
          idPaziente: this.detail.idPaziente,
          idTipoEsame: this.newExamType,
          descrizioneTipoEsame: tipoEsame[0].descrizione,
          richiedeImmagini: tipoEsame[0].richiedeImmagini,
          features: [],
          immagini: []
        }));

        this.exams[this.selectedPathology.id] = ex;

        this.showingExams = this.exams[this.selectedPathology.id];//.filter(x => x.idPatologia == this.selectedPathology.id);

        this.showAddExam = false;

        let translated = this.translate.instant('MESSAGES.Success');

        Swal.fire({
          icon: 'success',
          title: translated
        });
      },
        error => {
          this.error = error;
        }
      );
  }

  /*showDetailAndRestore(patient) {
    let idExam = this.selectedExam.idEsame;
  
    this.selectedExam = undefined;
    this.detail = patient;
    this.patientForm.patchValue(this.detail);
    this.detailOriginalId = this.detail.idPaziente;
  
    this.pazienti.getExams(patient.idPaziente)
      .pipe(finalize(() => {
        this.isBusy = false;
      }))
      .subscribe((res: EsamePazienteDTO[]) => {
        this.exams = res;
        this.selectedExam = this.exams.find(x => x.idEsame = idExam);
  
        console.log(idExam);
        console.log(this.selectedExam);
      },
        error => {
          this.error = error;
        }
      );
  }*/

  hideDetail() {
    this.detail = undefined;
    this.patientForm.reset();

    this.hideExamDetails();
  }

  hideExamDetails() {
    //this.examDetails = undefined;
  }

  newPatient() {
    this.detail = new PazienteDTO();
    this.detailOriginalId = this.detail.idPaziente;
  }

  onSubmit() {
    if (this.detailOriginalId != null) {
      this.pazienti.update(this.detailOriginalId, this.patientForm.value)
        .pipe(finalize(() => {
          this.isBusy = false;
        }))
        .subscribe((res) => {
          if (res) {
            let translated = this.translate.instant('MESSAGES.Success');

            Swal.fire({
              icon: 'success',
              title: translated
            });
          }

          this.hideDetail();
          this.refreshList();
        },
          error => {
            this.error = error;
          }
        );
    }
    else {
      this.pazienti.create(this.patientForm.value)
        .pipe(finalize(() => {
          this.isBusy = false;
        }))
        .subscribe((res) => {
          if (res) {
            let translated = this.translate.instant('MESSAGES.Success');

            Swal.fire({
              icon: 'success',
              title: translated
            });
          }

          this.hideDetail();
          this.refreshList();
        },
          error => {
            this.error = error;
          }
        );
    }
  }
}

/*

*/