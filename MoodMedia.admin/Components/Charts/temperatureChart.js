app.component("temperature-chart", {
  template: `<div id="temperatureChart" style="width:100%; height:400px;">Test</div>`,
  props: ["parentDates"],
  methods: {
    createChart() {
      if (this.parentDates.length > 0) {
        let datesArray = JSON.parse(JSON.stringify(this.parentDates));
        let data = {
          timestamp: [],
          temperatures: [],
        };
        // Define tempature
        const temperatures = datesArray.map((element) => {
          return element.temperature;
        });
        const timestamps = datesArray.map((element) => {
          let date = new Date(element.time);
          var dd = String(date.getDate()).padStart(2, "0");
          var mm = String(date.getMonth() + 1).padStart(2, "0");
          var yyyy = date.getFullYear();
          date = dd + "/" + mm + "/" + yyyy;
          return date;
        });

        data["timestamp"] = timestamps;
        data["temperatures"] = temperatures;

        // Define start and end date
        if (this.dateStart && this.dateEnd) {
          startDate = new Date(this.dateStart);
          endDate = new Date(this.endDate);
        } else {
          startDate = new Date(datesArray[0].time);
          endDate = new Date(datesArray[datesArray.length - 1].time);
        }
        // Define Date end
        const chart = Highcharts.chart("temperatureChart", {
          title: {
            text: "Tempertures",
          },

          yAxis: {
            title: {
              text: "Temperature (°C)",
            },
          },

          xAxis: {
            categories: data.timestamp,
            labels: {
              rotation: -90,
            },
          },

          series: [
            {
              name: "Temperature",
              data: data.temperatures,
            },
          ],

          responsive: {
            rules: [
              {
                condition: {
                  maxWidth: 500,
                },
                chartOptions: {
                  legend: {
                    layout: "horizontal",
                    align: "center",
                    verticalAlign: "bottom",
                  },
                },
              },
            ],
          },
        });
      }
    },
  },
  mounted() {
    this.$watch(
      "parentDates",
      (date) => {
        this.createChart();
      },
      { immediate: true }
    );
  },
});
