<template>
    <a-form :form="form" @submit="handleSubmit">
        <a-form-item v-bind="formItemLayout">
            <span slot="label">
                Họ tên
            </span>
            <a-input v-decorator="[
          'string',
          {
            rules: [{ required: true, message: 'Xin mời nhập tên!', whitespace: true }],
          },
        ]" />
        </a-form-item>

        <a-form-item v-bind="formItemLayout" label="Số điện thoại">
            <a-input v-decorator="['phone',
          {
            rules: [
              {
                minlength: 9, message: 'Số điện thoại không hợp lệ!'
              }
            ]
          }]"
                     style="width: 100%">
                <a-select slot="addonBefore"
                          v-decorator="['prefix', { initialValue: '84' }]"
                          style="width: 70px">
                    <a-select-option value="84">
                        +84
                    </a-select-option>

                </a-select>
            </a-input>
        </a-form-item>

        <a-form-item v-bind="formItemLayout" label="E-mail">
            <a-input v-decorator="[
          'email',
          {
            rules: [
              {
                type: 'email',
                message: 'E-mail không hợp lệ!'
              }
            ]
          }
        ]" />
        </a-form-item>
        <a-form-item v-bind="formItemLayout" label="Bình luận">
            <a-textarea required placeholder="Nhập bình luận của bạn..." :rows="4" />
        </a-form-item>



        <a-form-item v-bind="tailFormItemLayout">
            <a-button type="primary" html-type="submit" onclick="window.location.href = '_blank';">
                Đăng bình luận
            </a-button>
        </a-form-item>
    </a-form>
</template>

<script>


    export default {
        data() {
            return {
                confirmDirty: false,
                autoCompleteResult: [],
                formItemLayout: {
                    labelCol: {
                        xs: { span: 24 },
                        sm: { span: 8 },
                    },
                    wrapperCol: {
                        xs: { span: 24 },
                        sm: { span: 16 },
                    },
                },
                tailFormItemLayout: {
                    wrapperCol: {
                        xs: {
                            span: 24,
                            offset: 0,
                        },
                        sm: {
                            span: 16,
                            offset: 8,
                        },
                    },
                },
            };
        },
        beforeCreate() {
            this.form = this.$form.createForm(this, { name: 'submit' });
        },
        methods: {
            handleSubmit(e) {
                e.preventDefault();
                this.form.validateFieldsAndScroll((err, values) => {
                    if (!err) {
                        console.log('Received values of form: ', values);
                    }
                });
            },
            handleConfirmBlur(e) {
                const value = e.target.value;
                this.confirmDirty = this.confirmDirty || !!value;
            },
            compareToFirstPassword(rule, value, callback) {
                const form = this.form;
                if (value && value !== form.getFieldValue('password')) {
                    callback('Two passwords that you enter is inconsistent!');
                } else {
                    callback();
                }
            },
            validateToNextPassword(rule, value, callback) {
                const form = this.form;
                if (value && this.confirmDirty) {
                    form.validateFields(['confirm'], { force: true });
                }
                callback();
            },
            handleWebsiteChange(value) {
                let autoCompleteResult;
                if (!value) {
                    autoCompleteResult = [];
                } else {
                    autoCompleteResult = ['.com', '.org', '.net'].map(domain => `${value}${domain}`);
                }
                this.autoCompleteResult = autoCompleteResult;
            },
        },
    };
</script>