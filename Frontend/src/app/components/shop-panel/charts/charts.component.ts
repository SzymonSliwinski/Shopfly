import { Component, OnInit } from '@angular/core';
import { ChartService, DateRangeDto } from 'src/app/services/shop-panel-services/profile.service copy';

@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.scss']
})
export class ChartsComponent implements OnInit {
  dateRange1: DateRangeDto = {} as DateRangeDto;
  dateRange2: DateRangeDto = {} as DateRangeDto;
  dateRange3: DateRangeDto = {} as DateRangeDto;
  dateRange4: DateRangeDto = {} as DateRangeDto;
  dateRange5: DateRangeDto = {} as DateRangeDto;
  isLoaded1 = false;
  isLoaded4 = false;
  isLoaded5 = false;
  chart1Data: any = {
    labels: [],
    datasets: [
      {
        type: 'bar',
        label: 'Number of new orders',
        data: [],
        backgroundColor: '#42A5F5',
      }
    ]
  };

  chart4Data: any = {
    labels: [],
    datasets: [
      {
        type: 'bar',
        label: 'Number of closed orders',
        data: [],
        backgroundColor: '#42A5F5',
      }
    ]
  };


  chart5Data: any = {
    labels: [],
    datasets: [
      {
        type: 'bar',
        label: 'Number of new customers',
        data: [],
        backgroundColor: '#42A5F5',
      }
    ]
  };

  constructor(
    private readonly _chartService: ChartService
  ) { }

  async ngOnInit(): Promise<void> {
    this.dateRange1.from = new Date(new Date().setDate(new Date().getDate() - 7));
    this.dateRange1.to = new Date(new Date().setDate(new Date().getDate()));
    this.dateRange2.from = new Date(new Date().setDate(new Date().getDate() - 7));
    this.dateRange2.to = new Date(new Date().setDate(new Date().getDate()));
    this.dateRange3.from = new Date(new Date().setDate(new Date().getDate() - 7));
    this.dateRange3.to = new Date(new Date().setDate(new Date().getDate()));
    this.dateRange4.from = new Date(new Date().setDate(new Date().getDate() - 7));
    this.dateRange4.to = new Date(new Date().setDate(new Date().getDate()));
    this.dateRange5.from = new Date(new Date().setDate(new Date().getDate() - 7));
    this.dateRange5.to = new Date(new Date().setDate(new Date().getDate()));

    await this.onDate1Change();
    // await this.onDate2Change();
    // await this.onDate3Change();
    await this.onDate4Change();
    await this.onDate5Change();
  }


  async onDate1Change() {
    this.isLoaded1 = false;
    const chart1 = await this._chartService.getOrderChart(this.dateRange1);
    for (let prop in chart1) {
      let fixedMonth = (new Date(prop.toString()).getMonth()) + 1;
      fixedMonth < 10 ?
        this.chart1Data.labels.push(new Date(prop.toString()).getDate() + '.0' + fixedMonth.toString()) :
        this.chart1Data.labels.push(new Date(prop.toString()).getDate() + '.' + fixedMonth.toString())
      this.chart1Data.datasets[0].data.push(chart1[prop]);
    }
    this.isLoaded1 = true;
  }

  async onDate4Change() {
    this.isLoaded4 = false;
    const chart4 = await this._chartService.getCompleteOrdersChart(this.dateRange4);
    for (let prop in chart4) {
      let fixedMonth = (new Date(prop.toString()).getMonth()) + 1;
      fixedMonth < 10 ?
        this.chart4Data.labels.push(new Date(prop.toString()).getDate() + '.0' + fixedMonth.toString()) :
        this.chart4Data.labels.push(new Date(prop.toString()).getDate() + '.' + fixedMonth.toString())
      this.chart4Data.datasets[0].data.push(chart4[prop]);
    }
    this.isLoaded4 = true;
  }

  async onDate5Change() {
    this.isLoaded5 = false;
    const chart5 = await this._chartService.getNewUsersChart(this.dateRange5);
    for (let prop in chart5) {
      let fixedMonth = (new Date(prop.toString()).getMonth()) + 1;
      fixedMonth < 10 ?
        this.chart5Data.labels.push(new Date(prop.toString()).getDate() + '.0' + fixedMonth.toString()) :
        this.chart5Data.labels.push(new Date(prop.toString()).getDate() + '.' + fixedMonth.toString())
      this.chart5Data.datasets[0].data.push(chart5[prop]);
    }
    this.isLoaded5 = true;
  }
}
