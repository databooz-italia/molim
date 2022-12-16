import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CreaDiagnosiRequest, PazientiClient, GetPazientiResponse, ICreatePazienteRequest, IUpdatePazienteRequest, CreatePazienteRequest, UpdatePazienteRequest, PazienteDTO, EsamePazienteDTO, GetEsamiPazienteResponse, GetDiagnosiPazienteResponse, DiagnosiDTO, FileResponse, FeatureEsameDTO, GetPredizioniPazienteResponse, PredizioneDTO, ImmagineDTO, CreatePredizionePaziente } from './api.client';

@Injectable({
  providedIn: 'root'
})
export class PazientiService {

  constructor(@Inject(PazientiClient) private client: PazientiClient) { }

  getList(): Observable<PazienteDTO[]> {
    return this.client.getPazienti()
      .pipe(map((result: GetPazientiResponse) => {
        if (result)
          return result.pazienti;

        return [];
      }));
  }

  create(request: ICreatePazienteRequest): Observable<boolean> {
    return this.client.createPaziente(new CreatePazienteRequest(request))
      .pipe(map((result) => {
        return true;
      }));
  }

  update(id: string, requestData: IUpdatePazienteRequest): Observable<boolean> {
    return this.client.updatePaziente(id, new UpdatePazienteRequest(requestData))
      .pipe(map((result) => {
        return true;
      }));
  }

  delete(id: string): Observable<boolean> {
    return this.client.deletePaziente(id)
      .pipe(map((result) => {
        return true;
      }));
  }

  getExams(id: string): Observable<any[] | { [key: string]: EsamePazienteDTO[] }> {
    return this.client.getEsamiPaziente(id)
      .pipe(map((result: GetEsamiPazienteResponse) => {
        if (result)
          return result.esamiPaziente;

        return [];
      }));
  }

  getPredizioni(idPaziente: string): Observable<any[] | { [key: string]: PredizioneDTO[]}> {
    return this.client.getPredizioniPaziente(idPaziente)
      .pipe(map((result: GetPredizioniPazienteResponse) => {
        if (result)
          return result.predizioniPaziente;

        return [];
      }));
  }

  getDiagnosi(idPaziente: string): Observable<any[] | { [key: string]: DiagnosiDTO[]}> {
    return this.client.getDiagnosiPaziente(idPaziente)
      .pipe(map((result: GetDiagnosiPazienteResponse) => {
        if (result)
          return result.diagnosiPaziente;

        return [];
      }));
  }

  saveDiagnosi(idPaziente: string, idPatologia: string, data: Date, esito: string): Observable<boolean>
  {
    return this.client.creaDiagnosiPaziente(idPaziente, new CreaDiagnosiRequest({
      date: data, esito: esito, idPatologia: idPatologia, idPaziente: idPaziente
    }))
    .pipe(map((r) => {
      return true;
    }));
  }

  uploadFileImmagine(idPaziente: string, idEsame: number, file: File): Observable<number>
  {
    return this.client.uploadFileEsame(idPaziente, idEsame.toString(), { data: file, fileName: file.name })
      .pipe(map((result) => {
        return result;
      }));
  }

  uploadFileRoi(idImmagine: number, file: File): Observable<number>
  {
    return this.client.uploadROIImmagine(idImmagine.toString(), { data: file, fileName: file.name })
      .pipe(map((result) => {
        return result;
      }));
  }

  downloadFileImmagine(idPaziente, idEsame, idImmagine): Observable<FileResponse>
  {
    return this.client.downloadFileImmagine(idPaziente, idEsame, idImmagine)
      .pipe(map((result: FileResponse) => {
        if (result)
          return result;

        return null;
      }));
  }

  saveFeatureEsame(idPaziente: string, idEsame: number, featureEsame: FeatureEsameDTO)
  {
    return this.saveFeaturesEsame(idPaziente, idEsame, [featureEsame]);
  }

  saveFeaturesEsame(idPaziente: string, idEsame: number, featureEsame: FeatureEsameDTO[])
  {
    return this.client.saveFeatureEsame(idPaziente, idEsame, featureEsame)
      .pipe(map((result) => {
        return true;
      }));
  }

  saveEsame(idPaziente: string, idPatologia: string, idTipoEsame: string, date: Date) : Observable<number>
  {
    return this.client.saveEsame(idPaziente, new EsamePazienteDTO({
      data: date,
      idPaziente: idPaziente,
      idPatologia: idPatologia,
      idTipoEsame: idTipoEsame
    }))
    .pipe(map((result) => {
      return result;
    }));
  }

  requestPredizione(idPaziente: string, idPatologia: string, idImmagine: number, idRoi: number, idAlgoritmo: number): Observable<any[] | { [key: string]: PredizioneDTO[]}>
  {
    return this.client.createPredizionePaziente(idPaziente, new CreatePredizionePaziente({
      idPaziente: idPaziente,
      idPatologia: idPatologia,
      idAlgoritmo: idAlgoritmo,
      idImmagine: idImmagine,
      idRegioneDiInteresse: idRoi
    }))
    .pipe(map((result) => {
      return result.predizioniPaziente;
    }));
  }
}
