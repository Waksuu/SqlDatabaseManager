// Karma configuration file, see link for more information
// https://karma-runner.github.io/1.0/config/configuration-file.html

module.exports = function (config) {
  config.set({
    basePath: "./",
    port: 9876,
    colors: true,
    logLevel: config.LOG_INFO,

    frameworks: [
      'jasmine',
      "jasmine-matchers",
      '@angular-devkit/build-angular'
    ],
    plugins: [
      require('karma-jasmine'),
      require('karma-jasmine-matchers'),
      require('karma-chrome-launcher'),
      require('karma-coverage-istanbul-reporter'),
      require('karma-mocha-reporter'),
      require('karma-junit-reporter'),
      require('@angular-devkit/build-angular/plugins/karma')
    ],
    reporters: [
      "mocha",
      "coverage-istanbul",
      "junit"
    ],
    coverageIstanbulReporter: {
      dir: `.tests/coverage`,
      reports: [
        "text-summary",
        "html",
        "lcovonly"
      ]
    },
    junitReporter: {
      outputDir: `.tests/`,
      outputFile: "test-report.xml",
      suite: `suits`,
      useBrowserName: false
    },
    browsers: ["ChromeHeadless"],
    files: [],
    browserConsoleLogOptions: {
      terminal: true,
      level: "log"
    },
    mime: {
      "text/x-typescript": ["ts"]
    },
    client: {
      clearContext: false, // leave Jasmine Spec Runner output visible in browser
      captureConsole: true
    },
  });
};
