const gulp = require('gulp');
const browserify = require('browserify');
const source = require('vinyl-source-stream');
const buffer = require('vinyl-buffer');
const sourcemaps = require('gulp-sourcemaps');
const sass = require("gulp-sass")(require("sass"));
const clean = require('gulp-clean');
const concat = require('gulp-concat');
const babelify = require('babelify');

const paths = {
    scripts: {
        src: [
            './assets/js/scripts.js'
        ],
        dest: 'wwwroot/js/'
    },
    styles: {
        src: [
            './assets/scss/**/*.scss'
        ],
        dest: 'wwwroot/css/'
    }
};

function cleanDist() {
    return gulp.src('wwwroot/*', { read: false, allowEmpty: true })
        .pipe(clean());
}

function scripts() {
    return browserify({
        entries: [paths.scripts.src],
        debug: true,
        standalone: 'BlankMVC',
        transform: [babelify.configure({ presets: ['@babel/preset-env'] })]
    })
    .bundle()
    .pipe(source('scripts.js'))
    .pipe(buffer())
    .pipe(sourcemaps.init({ loadMaps: true }))
    .pipe(sourcemaps.write('./'))
    .pipe(gulp.dest(paths.scripts.dest));
}

function styles() {
    return gulp.src(paths.styles.src)
        .pipe(sass().on('error', sass.logError))
        .pipe(concat('styles.css')) // Concatenate files without minifying
        .pipe(gulp.dest(paths.styles.dest));
}

function watchFiles() {
    gulp.watch('./assets/scss/**/*.scss', styles);
    gulp.watch('./assets/js/**/*.js', scripts);
}

const build = gulp.series(cleanDist, gulp.parallel(scripts, styles));

exports.clean = cleanDist;
exports.scripts = scripts;
exports.watch = watchFiles;
exports.styles = styles;
exports.build = build;
exports.default = build;